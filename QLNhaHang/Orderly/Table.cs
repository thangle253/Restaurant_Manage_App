using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Orderly.Model;


namespace Orderly
{
   
    public partial class Table : Form
    {
        // Biến toàn cục để lưu danh sách bàn (BanAn)
        private List<BanAn> allTables;
        private QLNhaHangDB context; // Khai báo DbContext
        public event Action<int, string> BanNameUpdated;
        public Table()
        {
            InitializeComponent();
            context = new QLNhaHangDB(); // Khởi tạo DbContext


        }

        private void Table_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo DbContext
                using (var context = new QLNhaHangDB())
                {
                    // Lấy dữ liệu từ bảng BanAn
                    allTables = context.BanAns.ToList();

                    // Đổ dữ liệu lên DataGridView
                    BindTableGrid(allTables);

                    // Đổ dữ liệu vào ComboBox với 2 trạng thái "Trống" và "Đã đặt"
                    cmbPhanLoai.Items.Add("Trống");
                    cmbPhanLoai.Items.Add("Đã đặt");
                    cmbPhanLoai.SelectedIndex = 0; // Chọn mặc định là "Trống"

                    // Cập nhật số lượng bàn trống và bàn đã đặt
                    UpdateTableCount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // Hàm đổ dữ liệu vào DataGridView
        private void BindTableGrid(List<BanAn> listBanAn)
        {
            if (listBanAn == null || listBanAn.Count == 0)
            {
                MessageBox.Show("Danh sách bàn không có dữ liệu.");
                return;
            }

            dgvTable.Rows.Clear();
            foreach (var item in listBanAn)
            {
                int index = dgvTable.Rows.Add();
                dgvTable.Rows[index].Cells[0].Value = item.MaBan;
                dgvTable.Rows[index].Cells[1].Value = item.TenBan;
                dgvTable.Rows[index].Cells[2].Value = item.TrangThai;
                dgvTable.Rows[index].Cells[3].Value = item.SoLuongChoNgoi;
            }
        }

        private void cmbPhanLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cmbPhanLoai.SelectedItem.ToString();

            // Lọc danh sách bàn theo trạng thái được chọn
            List<BanAn> filteredTables = allTables
                .Where(b => b.TrangThai == selectedStatus)
                .ToList();

            // Đổ dữ liệu lên DataGridView sau khi lọc
            BindTableGrid(filteredTables);

            // Cập nhật số lượng bàn trống và bàn đã đặt
            UpdateTableCount();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tải lại danh sách bàn từ cơ sở dữ liệu
                using (var context = new QLNhaHangDB())
                {
                    allTables = context.BanAns.ToList(); // Cập nhật danh sách allTables
                }

                // Hiển thị danh sách bàn mới nhất lên DataGridView
                BindTableGrid(allTables);

                // Cập nhật số lượng bàn trống và bàn đã đặt
                UpdateTableCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ (không phải header)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                var selectedRow = dgvTable.Rows[e.RowIndex];

                // Kiểm tra nếu dòng không có dữ liệu (thường là dòng cuối)
                if (selectedRow.Cells[0].Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Dòng này không có bàn nào cả!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy giá trị của các cột trong dòng được chọn
                string maBan = selectedRow.Cells[0].Value.ToString();
                string tenBan = selectedRow.Cells[1].Value?.ToString();
                string trangThai = selectedRow.Cells[2].Value?.ToString();
                int soLuongChoNgoi = int.Parse(selectedRow.Cells[3].Value?.ToString() ?? "0");

                // Đổ dữ liệu vào các TextBox tương ứng
                txtMaBan.Text = maBan;
                txtTenBan.Text = tenBan;
                txtTrangThai.Text = trangThai;
                txtSLChoNgoi.Text = soLuongChoNgoi.ToString();
            }
        }
        private void UpdateTableCount()
        {
            // Đếm số bàn trống và số bàn đã đặt
            int slTrong = allTables.Count(b => b.TrangThai == "Trống");
            int slDat = allTables.Count(b => b.TrangThai == "Đã đặt");

            // Cập nhật vào các TextBox
            txtSLTrong.Text = slTrong.ToString();
            txtSLDat.Text = slDat.ToString();
        }
        private void UpdateOtherForms(int maBan, string tenBan)//code lâm
        {
            // Kiểm tra xem cột "ColMaBan" có tồn tại trong DataGridView không
            if (dgvTable.Columns.Contains("ColMaBan"))
            {
                // Cập nhật DataGridView
                var row = dgvTable.Rows.Cast<DataGridViewRow>()
                                         .FirstOrDefault(r => r.Cells["ColMaBan"].Value != null && (int)r.Cells["ColMaBan"].Value == maBan);

                if (row != null)
                {
                    row.Cells["ColTenBan"].Value = tenBan;  // Cập nhật tên bàn
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn với mã này trong DataGridView.");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy cột 'ColMaBan' trong DataGridView.");
            }

            // Gọi sự kiện để thông báo cập nhật
            BanNameUpdated?.Invoke(maBan, tenBan);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu giá trị ban đầu của trạng thái bàn
                string trangThaiBanDau = txtTrangThai.Text;

                // Lấy thông tin bàn từ các TextBox
                if (!int.TryParse(txtMaBan.Text, out int maBan))
                {
                    MessageBox.Show("Mã bàn không hợp lệ.");
                    return;
                }

                string tenBan = txtTenBan.Text;
                string trangThai = txtTrangThai.Text;
                int soLuongChoNgoi;
                if (!int.TryParse(txtSLChoNgoi.Text, out soLuongChoNgoi))
                {
                    MessageBox.Show("Số lượng chỗ ngồi không hợp lệ.");
                    return;
                }

                // Kiểm tra dữ liệu hợp lệ
                if (string.IsNullOrEmpty(tenBan))
                {
                    MessageBox.Show("Tên bàn không được để trống.");
                    return;
                }

                // Tìm bàn cần sửa trong cơ sở dữ liệu
                var banAn = context.BanAns.FirstOrDefault(b => b.MaBan == maBan);

                if (banAn != null)
                {
                    // Kiểm tra nếu có sự thay đổi về mã bàn hoặc trạng thái
                    if (banAn.MaBan != maBan)
                    {
                        MessageBox.Show("Không thể thay đổi mã bàn.");
                        return;
                    }

                    if (banAn.TrangThai != trangThai)
                    {
                        MessageBox.Show("Không thể thay đổi trạng thái bàn.");
                        // Khôi phục lại giá trị ban đầu của trạng thái
                        txtTrangThai.Text = trangThaiBanDau;
                        return;
                    }

                    // Cập nhật tên bàn và số lượng chỗ ngồi
                    banAn.TenBan = tenBan;
                    banAn.SoLuongChoNgoi = soLuongChoNgoi;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    // Cập nhật lại DataGridView
                    dgvTable.Rows.Clear();
                    var updatedBanAnList = context.BanAns.ToList();
                    foreach (var ban in updatedBanAnList)
                    {
                        dgvTable.Rows.Add(ban.MaBan, ban.TenBan, ban.TrangThai, ban.SoLuongChoNgoi);
                    }

                    // Cập nhật lại tên bàn và số lượng chỗ ngồi ở các form khác (nếu có)
                    UpdateOtherForms(banAn.MaBan, banAn.TenBan);

                    // Cập nhật số lượng chỗ ngồi trong DataGridView (nếu cần)
                    var rowToUpdate = dgvTable.Rows.Cast<DataGridViewRow>()
                        .FirstOrDefault(r => r.Cells["ColMaBan"].Value != null && (int)r.Cells["ColMaBan"].Value == maBan);
                    if (rowToUpdate != null)
                    {
                        rowToUpdate.Cells["ColSoLuongChoNgoi"].Value = soLuongChoNgoi;
                    }

                    MessageBox.Show("Cập nhật bàn thành công.");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn với mã này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }
    }
}

    

