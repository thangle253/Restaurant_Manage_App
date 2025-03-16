using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Orderly.Model;
using Orderly.UC;
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
            LoadTables();
        }

        private void LoadTables()
        {
            flpTable.Controls.Clear(); // Xóa bàn cũ trước khi load lại

            using (var context = new QLNhaHangDB())
            {
                var banAnList = context.BanAns.ToList();
                foreach (var ban in banAnList)
                {
                    // Tạo một UserControl cho bàn ăn
                    var uc = new ucTable
                    {
                        TableID = ban.MaBan,
                        TableName = ban.TenBan,
                        Status = ban.TrangThai
                    };

                    // Đặt hình ảnh bàn (có thể thay đổi theo trạng thái)
                   uc.SetTableData(ban.MaBan, ban.TenBan, ban.TrangThai, Image.FromFile("C:\\Users\\APPLE\\Documents\\Restaurant_Manage_App\\QLNhaHang\\Orderly\\Resources\\table_Oderr.png"));


                    // Xử lý sự kiện khi chọn bàn
                    uc.TableSelected += Uc_TableSelected;

                    // Thêm UserControl vào FlowLayoutPanel
                    flpTable.Controls.Add(uc);
                }
            }
        }

        // Sự kiện khi chọn bàn
        private void Uc_TableSelected(object sender, EventArgs e)
        {
            var selectedTable = sender as ucTable;
            MessageBox.Show($"Bạn đã chọn {selectedTable.TableName} - Trạng thái: {selectedTable.Status}");
        }

        private void Order_Load(object sender, EventArgs e)
        {
            try
            { 

                LoadTables();


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

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
