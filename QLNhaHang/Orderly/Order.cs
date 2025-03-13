using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Orderly.Model;
namespace Orderly
{
    public partial class Order : Form
    {
        private QLNhaHangDB context; // Khai báo biến DbContext
        private int selectedTable = -1;  // Lưu bàn đã chọn
        private List<MonAn> listMonAn; // Danh sách món ăn
        public Order()
        {
            InitializeComponent();
            context = new QLNhaHangDB(); // Khởi tạo DbContext
            LoadButtons(); // Tải dữ liệu vào các nút
        }
        private void LoadButtons() //TaiDuLieuNutBan()
        {
            using (var context = new QLNhaHangDB())
            {
                var banAnList = context.BanAns.ToList(); // Lấy danh sách bàn từ cơ sở dữ liệu
                foreach (var ban in banAnList)
                {
                    Button btnBan = this.Controls.Find($"btnBan{ban.MaBan}", true).FirstOrDefault() as Button;
                    if (btnBan != null)
                    {
                        // Cập nhật thông tin hiển thị của nút bàn
                        btnBan.Text = $"{ban.TenBan}\n{ban.TrangThai}";
                        btnBan.BackColor = ban.TrangThai == "Trống" ? Color.Green : Color.Red;

                        // Đảm bảo sự kiện Click vẫn hoạt động
                        btnBan.Click -= btnBan20_Click; // Xóa sự kiện cũ
                        btnBan.Click += btnBan20_Click; // Gắn lại sự kiện
                    }
                }
            }
        }
        public void UpdateButton(int maBan, string tenBan, string trangThai) //
        {
            Button btnBan = this.Controls.Find($"btnBan{maBan}", true).FirstOrDefault() as Button;
            if (btnBan != null)
            {
                btnBan.Text = $"{tenBan}\n{trangThai}";
                btnBan.BackColor = trangThai == "Trống" ? Color.Green : Color.Red;
            }
        }
        private void Order_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách loại món ăn từ cơ sở dữ liệu
                List<LoaiMon> listLoaiMon = context.LoaiMons.ToList();
                FillLoaiMonCombobox(listLoaiMon);

                // Lắng nghe sự kiện thay đổi loại món
                cmbLoai.SelectedIndexChanged += (s, ev) => LoadMonAnBasedOnLoaiMon();

                // Cập nhật màu sắc các nút bàn dựa trên trạng thái từ cơ sở dữ liệu
                UpdateTableColors();
                //đổ dữ liệu tên các bàn vào cmb
                LoadBanToCombobox();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void FillLoaiMonCombobox(List<LoaiMon> listLoaiMon)
        {

            cmbLoai.DataSource = listLoaiMon;
            cmbLoai.DisplayMember = "TenLoaiMon";  // Hiển thị tên loại món ăn
            cmbLoai.ValueMember = "MaLoaiMon";     // Giá trị là mã loại món ăn
            cmbLoai.SelectedIndex = 0;             // Chọn loại món đầu tiên mặc định
        }

        private void LoadMonAnBasedOnLoaiMon()
        {
            try
            {
                // Lấy mã loại món đã chọn
                int selectedMaLoaiMon = (int)cmbLoai.SelectedValue;

                // Lấy danh sách món ăn thuộc loại đã chọn từ cơ sở dữ liệu
                listMonAn = context.MonAns
                                    .Where(m => m.MaLoaiMon == selectedMaLoaiMon)
                                    .ToList();

                // Đổ dữ liệu vào ComboBox MonAn
                cmbMon.DataSource = listMonAn;
                cmbMon.DisplayMember = "TenMon";  // Hiển thị tên món ăn
                cmbMon.ValueMember = "MaMon";     // Giá trị là mã món ăn
                cmbMon.SelectedIndex = 0;         // Chọn món ăn đầu tiên mặc định
            }
            catch
            {
                MessageBox.Show("Không có món ăn nào trong loại này, vui lòng thêm món ăn vào !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBan20_Click(object sender, EventArgs e) //code của lâm
        {
            Button btn = sender as Button;
            if (btn != null)
            {

                string tableIdString = btn.Name.Replace("btnBan", "");
                int tableNumber;

                if (!int.TryParse(tableIdString, out tableNumber))
                {
                    MessageBox.Show("Lỗi: Mã bàn không hợp lệ. Vui lòng kiểm tra lại tên nút.");
                    return;
                }

                using (var context = new QLNhaHangDB())
                {
                    var banAn = context.BanAns.FirstOrDefault(b => b.MaBan == tableNumber);
                    if (banAn == null)
                    {
                        MessageBox.Show($"Bàn {tableNumber} không tồn tại trong hệ thống.");
                        return;
                    }

                    // Phần còn lại xử lý dữ liệu
                    var donHang = context.DonHangs
                                         .FirstOrDefault(dh => dh.MaBan == tableNumber && dh.TrangThai == "Đã đặt");

                    if (donHang != null)
                    {
                        LoadOrderDetailsToGridView(donHang.MaDonHang);
                        txtTongTien.Text = $"{donHang.TongTien:N0} VND";
                        selectedTable = tableNumber;
                        MessageBox.Show($"Bàn {tableNumber} đã được đặt. Dữ liệu đã được hiển thị.");
                    }
                    else
                    {
                        // Bàn trống
                        selectedTable = tableNumber;
                        dgvOrder.Rows.Clear();
                        txtTongTien.Text = "0 VND";
                        MessageBox.Show($"Bạn đã chọn bàn {tableNumber}. Hiện tại bàn này trống.");
                    }
                }
            }
        }
        private void LoadOrderDetailsToGridView(int maDonHang)
        {
            try
            {
                // Lấy danh sách chi tiết đơn hàng
                var chiTietDonHangList = context.ChiTietDonHangs
                                                .Where(ct => ct.MaDonHang == maDonHang)
                                                .Select(ct => new
                                                {
                                                    TenMon = ct.MonAn.TenMon,
                                                    SoLuong = ct.SoLuong,
                                                    GiaTien = ct.MonAn.GiaTien,
                                                    ThanhTien = ct.SoLuong * ct.MonAn.GiaTien
                                                })
                                                .ToList();

                // Xóa dữ liệu cũ trên DataGridView
                dgvOrder.Rows.Clear();

                // Đổ dữ liệu mới lên DataGridView
                foreach (var item in chiTietDonHangList)
                {
                    dgvOrder.Rows.Add(item.TenMon, item.SoLuong, item.GiaTien, item.ThanhTien);
                }

                // Cập nhật tổng tiền
                CalculateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết đơn hàng: " + ex.Message);
            }
        }

        private void UpdateTableColors()
        {
            try
            {
                // Lấy danh sách bàn từ cơ sở dữ liệu
                var banAnList = context.BanAns.ToList();

                // Duyệt qua tất cả bàn và cập nhật màu sắc
                foreach (var ban in banAnList)
                {
                    var btn = this.Controls.Find($"btnBan{ban.MaBan}", true).FirstOrDefault() as Button;
                    if (btn != null)
                    {
                        // Kiểm tra nếu bàn có món
                        bool hasOrder = context.DonHangs
                                            .Any(dh => dh.MaBan == ban.MaBan && dh.TrangThai == "Đã đặt" &&
                                                       context.ChiTietDonHangs.Any(ct => ct.MaDonHang == dh.MaDonHang));

                        // Đặt màu sắc dựa trên trạng thái
                        btn.BackColor = hasOrder ? Color.Yellow : SystemColors.Control;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật màu bàn: " + ex.Message);
            }
        }
        public void UpdateBanName(int maBan, string tenBan)//code của lâm
        {
            var btnBan = this.Controls.Find($"btnBan{maBan}", true).FirstOrDefault() as Button;
            if (btnBan != null)
            {
                btnBan.Text = $"Bàn {maBan}: {tenBan}";
            }
            else
            {
                MessageBox.Show($"Không tìm thấy nút cho bàn {maBan} trong FormOrder.");
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (selectedTable == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món.");
                return;
            }

            try
            {
                // Kiểm tra số lượng món
                int soLuong = (int)numericUpDownSoLuong.Value;
                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng món phải lớn hơn 0.");
                    return;
                }

                // Lấy thông tin món ăn từ ComboBox
                int maMon = (int)cmbMon.SelectedValue;
                string tenMon = cmbMon.Text;
                decimal giaTien = listMonAn.FirstOrDefault(m => m.MaMon == maMon)?.GiaTien ?? 0;

                // Kiểm tra nếu bàn đã có đơn hàng
                var donHang = context.DonHangs.FirstOrDefault(dh => dh.MaBan == selectedTable && dh.TrangThai == "Đã đặt");
                if (donHang == null)
                {
                    // Tạo mới đơn hàng
                    donHang = new DonHang
                    {
                        MaDonHang = context.DonHangs.Max(d => (int?)d.MaDonHang) + 1 ?? 1, // Tạo mã đơn hàng tự động
                        MaBan = selectedTable,
                        NgayDat = DateTime.Now,
                        TrangThai = "Đã đặt",
                        TongTien = 0 // Tạm thời chưa tính tổng tiền
                    };

                    context.DonHangs.Add(donHang);

                    // Cập nhật trạng thái bàn
                    var banAn = context.BanAns.FirstOrDefault(b => b.MaBan == selectedTable);
                    if (banAn != null)
                    {
                        banAn.TrangThai = "Đã đặt"; // Cập nhật trạng thái bàn thành "Đã đặt"
                    }
                }

                // Kiểm tra nếu món đã tồn tại trong ChiTietDonHang
                var chiTiet = context.ChiTietDonHangs.FirstOrDefault(ct => ct.MaDonHang == donHang.MaDonHang && ct.MaMon == maMon);
                if (chiTiet != null)
                {
                    // Nếu món đã tồn tại, cộng dồn số lượng
                    chiTiet.SoLuong += soLuong;
                }
                else
                {
                    // Nếu món chưa tồn tại, thêm mới
                    chiTiet = new ChiTietDonHang
                    {
                        MaChiTiet = context.ChiTietDonHangs.Max(ct => (int?)ct.MaChiTiet) + 1 ?? 1, // Tạo mã chi tiết tự động
                        MaDonHang = donHang.MaDonHang,
                        MaMon = maMon,
                        SoLuong = soLuong
                    };

                    context.ChiTietDonHangs.Add(chiTiet);
                }

                // Cập nhật tổng tiền đơn hàng
                donHang.TongTien += soLuong * giaTien;

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();

                // Cập nhật giao diện DataGridView
                bool monTonTai = false;
                foreach (DataGridViewRow row in dgvOrder.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == tenMon)
                    {
                        // Nếu món đã tồn tại, cộng dồn số lượng và cập nhật tổng tiền
                        int currentSoLuong = int.Parse(row.Cells[1].Value.ToString());
                        row.Cells[1].Value = currentSoLuong + soLuong; // Cộng dồn số lượng
                        row.Cells[3].Value = (currentSoLuong + soLuong) * giaTien; // Cập nhật thành tiền
                        monTonTai = true;
                        break;
                    }
                }

                if (!monTonTai)
                {
                    // Nếu món chưa tồn tại, thêm mới vào DataGridView
                    dgvOrder.Rows.Add(tenMon, soLuong, giaTien, soLuong * giaTien);
                }

                // Cập nhật tổng tiền hiển thị
                CalculateTotalAmount();

                // Cập nhật thống kê
                var thongKe = context.ThongKes
                    .FirstOrDefault(tk => tk.MaBan == selectedTable &&
                                          DbFunctions.TruncateTime(tk.Ngay) == DbFunctions.TruncateTime(DateTime.Now));
                if (thongKe == null)
                {
                    // Nếu chưa có thống kê, thêm mới
                    thongKe = new ThongKe
                    {
                        MaBan = selectedTable,
                        Ngay = DateTime.Now.Date,
                        SoLuongMon = soLuong,
                        TongTien = soLuong * giaTien
                    };
                    context.ThongKes.Add(thongKe);
                }
                else
                {
                    // Nếu đã có thống kê, cộng dồn số lượng món và tổng tiền
                    thongKe.SoLuongMon += soLuong;
                    thongKe.TongTien += soLuong * giaTien;
                }

                context.SaveChanges();

                // Đổi màu nút bàn thành vàng
                var btn = this.Controls.Find($"btnBan{selectedTable}", true).FirstOrDefault() as Button;
                if (btn != null)
                {
                    btn.BackColor = Color.Yellow;
                    btn.Text = $"{btn.Text.Split('\n')[0]}\nĐã đặt"; // Cập nhật chữ trên nút bàn thành "Đã đặt"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message);
            }

        }
        private void CalculateTotalAmount()
        {
            var donHang = context.DonHangs.FirstOrDefault(dh => dh.MaBan == selectedTable);
            decimal tongTien = donHang?.TongTien ?? 0;

            // Hiển thị số tiền với định dạng "xxx,xxx VND"
            txtTongTien.Text = $"{tongTien:N0} VND";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Hủy DbContext khi form đóng
            context?.Dispose();
            base.OnFormClosed(e);
        }
        private void LoadBanToCombobox()
        {
            try
            {
                // Tạo danh sách bàn từ "Bàn 1" đến "Bàn 20"
                List<string> danhSachBan = Enumerable.Range(1, 20)
                                                     .Select(i => $"Bàn {i}")
                                                     .Reverse() // Đảo ngược danh sách
                                                     .ToList();

                // Gán dữ liệu vào ComboBox
                cmbChonBanDoi.DataSource = danhSachBan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bàn: " + ex.Message);
            }
        }

        private void btnDoiBan_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTable == -1)
                {
                    MessageBox.Show("Vui lòng chọn bàn cần đổi trước.");
                    return;
                }

                // Lấy bàn muốn đổi từ ComboBox
                string selectedBanDoi = cmbChonBanDoi.SelectedItem.ToString();
                int newTableNumber = int.Parse(selectedBanDoi.Split(' ')[1]); // Bàn muốn đổi

                // Kiểm tra bàn muốn đổi có trống không
                var banDoi = context.BanAns.FirstOrDefault(b => b.MaBan == newTableNumber);
                if (banDoi == null || banDoi.TrangThai == "Đã đặt")
                {
                    MessageBox.Show($"Bàn {newTableNumber} đã được đặt. Không thể đổi.");
                    return;
                }

                // Cập nhật thông tin bàn trong cơ sở dữ liệu
                var donHang = context.DonHangs.FirstOrDefault(dh => dh.MaBan == selectedTable && dh.TrangThai == "Đã đặt");
                if (donHang != null)
                {
                    // Chuyển đơn hàng sang bàn mới
                    donHang.MaBan = newTableNumber; // Cập nhật bàn mới cho đơn hàng

                    // Cập nhật trạng thái bàn cũ
                    var banCu = context.BanAns.FirstOrDefault(b => b.MaBan == selectedTable);
                    if (banCu != null)
                    {
                        banCu.TrangThai = "Trống"; // Đổi trạng thái bàn cũ thành "Trống"
                    }

                    // Cập nhật trạng thái bàn mới
                    banDoi.TrangThai = "Đã đặt"; // Đổi trạng thái bàn mới thành "Đã đặt"

                    // Cập nhật bảng thống kê ThongKe
                    var thongKe = context.ThongKes
                        .FirstOrDefault(tk => tk.MaBan == selectedTable && DbFunctions.TruncateTime(tk.Ngay) == DbFunctions.TruncateTime(DateTime.Now));

                    if (thongKe != null)
                    {
                        // Cập nhật mã bàn trong bảng ThongKe
                        thongKe.MaBan = newTableNumber;
                    }

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    // Cập nhật giao diện
                    var btnBanCu = this.Controls.Find($"btnBan{selectedTable}", true).FirstOrDefault() as Button;
                    if (btnBanCu != null)
                    {
                        btnBanCu.BackColor = SystemColors.Control; // Trả lại màu mặc định cho bàn cũ
                        btnBanCu.Text = $"Bàn {selectedTable}\nTrống"; // Cập nhật lại tên bàn cũ
                    }

                    var btnBanMoi = this.Controls.Find($"btnBan{newTableNumber}", true).FirstOrDefault() as Button;
                    if (btnBanMoi != null)
                    {
                        btnBanMoi.BackColor = Color.Yellow; // Đổi màu vàng cho bàn mới
                        btnBanMoi.Text = $"Bàn {newTableNumber}\nĐã đặt"; // Cập nhật lại tên bàn mới
                    }

                    // Xóa DataGridView và tổng tiền của bàn cũ
                    dgvOrder.Rows.Clear();
                    txtTongTien.Text = "0 VND";

                    // Hiển thị thông báo thành công
                    MessageBox.Show($"Đã đổi bàn {selectedTable} sang bàn {newTableNumber} thành công!");

                    // Reset bàn đã chọn
                    selectedTable = -1;
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy đơn hàng ở bàn {selectedTable} để đổi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi bàn: " + ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedTable == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán.");
                return;
            }

            try
            {
                using (var context = new QLNhaHangDB())
                {
                    // Lấy bàn đang chọn
                    var banAn = context.BanAns.FirstOrDefault(b => b.MaBan == selectedTable);
                    if (banAn == null)
                    {
                        MessageBox.Show($"Bàn {selectedTable} không tồn tại.");
                        return;
                    }

                    // Lấy đơn hàng của bàn
                    var donHang = context.DonHangs
                                         .FirstOrDefault(dh => dh.MaBan == selectedTable && dh.TrangThai == "Đã đặt");

                    if (donHang == null)
                    {
                        MessageBox.Show("Không có đơn hàng nào để thanh toán.");
                        return;
                    }

                    // Lấy chi tiết đơn hàng
                    var chiTietDonHangs = context.ChiTietDonHangs
                                                 .Where(ct => ct.MaDonHang == donHang.MaDonHang)
                                                 .ToList();

                    // Chuyển đổi chi tiết đơn hàng thành ChiTietHoaDon
                    var chiTietHoaDonList = chiTietDonHangs.Select(ct => new ChiTietHoaDon
                    {
                        TenMon = ct.MonAn.TenMon,
                        SoLuong = ct.SoLuong,
                        GiaTien = ct.MonAn.GiaTien,
                        ThanhTien = ct.SoLuong * ct.MonAn.GiaTien
                    }).ToList();

                    // Lấy giá trị TongTien, nếu là null thì gán giá trị mặc định là 0
                    decimal tongTien = donHang.TongTien ?? 0;

                    // Mở form báo cáo và truyền dữ liệu
                    var reportForm = new Report();
                    reportForm.SetReportData(banAn.TenBan, tongTien, chiTietHoaDonList);
                    reportForm.ShowDialog();

                    // Xóa chi tiết đơn hàng
                    context.ChiTietDonHangs.RemoveRange(chiTietDonHangs);

                    // Xóa đơn hàng
                    context.DonHangs.Remove(donHang);

                    // Cập nhật trạng thái bàn
                    banAn.TrangThai = "Trống";

                    // Lưu thay đổi
                    context.SaveChanges();

                    // Cập nhật giao diện
                    dgvOrder.Rows.Clear();
                    txtTongTien.Text = "0 VND";
                    var btn = this.Controls.Find($"btnBan{selectedTable}", true).FirstOrDefault() as Button;
                    if (btn != null)
                    {
                        btn.BackColor = Color.White; // Đổi thành màu trắng
                        btn.Text = $"{banAn.TenBan}\nTrống";
                    }

                    // Thông báo thành công
                    MessageBox.Show($"Thanh toán bàn {selectedTable} thành công!");

                    // Reset bàn đã chọn
                    selectedTable = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
            }

        }

    }
}
