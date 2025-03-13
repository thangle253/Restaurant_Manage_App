using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orderly.Model;


namespace Orderly
{
    public partial class Categogy : Form
    {
        private QLNhaHangDB context; // Khởi tạo DbContext cho cơ sở dữ liệu
        public Categogy()
        {
            InitializeComponent();
            context = new QLNhaHangDB(); // Kết nối tới cơ sở dữ liệu
        }
        private void LoadData()
        {

            try
            {
                // Lấy danh sách loại món từ bảng LoaiMon
                var loaiMonList = context.LoaiMons
                    .Select(loai => new
                    {
                        loai.MaLoaiMon,
                        loai.TenLoaiMon
                    })
                    .ToList();  // Chuyển kết quả thành danh sách

                // Xóa các dòng cũ trước khi đổ dữ liệu mới
                dgvCategogy.Rows.Clear();

                // Duyệt qua danh sách loại món và thêm vào DataGridView
                foreach (var loai in loaiMonList)
                {
                    dgvCategogy.Rows.Add(loai.MaLoaiMon, loai.TenLoaiMon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgvCategogy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng nhấn vào một ô trong DataGridView (không phải header)
                if (e.RowIndex >= 0)
                {
                    // Lấy giá trị từ các cột của dòng đã nhấn
                    int maLoaiMon = Convert.ToInt32(dgvCategogy.Rows[e.RowIndex].Cells[0].Value); // MaLoaiMon
                    string tenLoaiMon = dgvCategogy.Rows[e.RowIndex].Cells[1].Value.ToString(); // TenLoaiMon

                    // Gán giá trị cho các TextBox hoặc các điều khiển khác trên form
                    txtMaLoaiMon.Text = maLoaiMon.ToString();  // Gán mã loại món vào TextBox
                    txtTenLoaiMon.Text = tenLoaiMon;  // Gán tên loại món vào TextBox hoặc Label

                    // Bạn có thể thực hiện các thao tác khác tại đây, ví dụ như mở bảng các món ăn theo loại này
                    // hoặc hiển thị thông tin chi tiết hơn nếu cần.
                }
            }
            catch
            {
                MessageBox.Show("Không có loại món nào ở dòng này !", "Thông báo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
                if (string.IsNullOrEmpty(txtMaLoaiMon.Text) || string.IsNullOrEmpty(txtTenLoaiMon.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã loại món và tên loại món.");
                    return;
                }

                int maLoaiMon;
                string tenLoaiMon = txtTenLoaiMon.Text.Trim();

                // Kiểm tra nếu txtMaLoaiMon có chứa giá trị hợp lệ
                if (!int.TryParse(txtMaLoaiMon.Text, out maLoaiMon))
                {
                    MessageBox.Show("Mã loại món phải là số.");
                    return;
                }

                // Kiểm tra xem loại món với MaLoaiMon đã tồn tại chưa
                var loaiMon = context.LoaiMons.FirstOrDefault(lm => lm.MaLoaiMon == maLoaiMon);

                if (loaiMon != null)
                {
                    // Nếu tồn tại, kiểm tra tên loại món có khớp không
                    if (loaiMon.TenLoaiMon.Equals(tenLoaiMon, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Loại món với mã {maLoaiMon} và tên \"{tenLoaiMon}\" đã tồn tại.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show($"Mã loại món {maLoaiMon} đã tồn tại với tên khác: {loaiMon.TenLoaiMon}.");
                        return;
                    }
                }

                // Thêm loại món mới vào cơ sở dữ liệu
                LoaiMon newLoaiMon = new LoaiMon
                {
                    MaLoaiMon = maLoaiMon,
                    TenLoaiMon = tenLoaiMon
                };

                context.LoaiMons.Add(newLoaiMon);
                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                LoadCategoryData();

                // Reset ô nhập liệu
                txtMaLoaiMon.Clear();
                txtTenLoaiMon.Clear();

                // Gọi phương thức load lại dữ liệu (nếu cần hiển thị danh sách loại món)


                MessageBox.Show("Thêm loại món mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại món: " + ex.Message);
            }
        }

        private void Categogy_Load(object sender, EventArgs e)
        {
            LoadData(); // Gọi hàm LoadData để tải dữ liệu từ bảng LoaiMon
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategogy.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn loại món cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dgvCategogy.SelectedRows[0];
                int maLoaiMon = int.Parse(selectedRow.Cells[0].Value.ToString());
                string tenLoaiMon = selectedRow.Cells[1].Value.ToString();

                // Hiển thị thông báo xác nhận
                DialogResult confirmResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa loại món ăn \"{tenLoaiMon}\" (Mã: {maLoaiMon})?",
                    "Xác Nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Kiểm tra các món ăn liên quan đến loại món này
                    var relatedMonAns = context.MonAns.Where(m => m.MaLoaiMon == maLoaiMon).ToList();
                    if (relatedMonAns.Any())
                    {
                        // Xóa các món ăn liên quan trước
                        context.MonAns.RemoveRange(relatedMonAns);
                        context.SaveChanges();
                    }

                    // Xóa loại món khỏi cơ sở dữ liệu
                    var loaiMon = context.LoaiMons.FirstOrDefault(lm => lm.MaLoaiMon == maLoaiMon);
                    if (loaiMon != null)
                    {
                        context.LoaiMons.Remove(loaiMon);
                        context.SaveChanges();

                        MessageBox.Show("Xóa loại món ăn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategoryData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy loại món ăn cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa loại món ăn: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadCategoryData()
        {
            try
            {
                // Xóa các dòng cũ trong DataGridView
                dgvCategogy.Rows.Clear();

                // Tải lại tất cả loại món từ cơ sở dữ liệu
                var loaiMonList = context.LoaiMons
                    .Select(loai => new
                    {
                        loai.MaLoaiMon,
                        loai.TenLoaiMon
                    })
                    .ToList();

                // Duyệt qua danh sách loại món và thêm vào DataGridView
                foreach (var loai in loaiMonList)
                {
                    dgvCategogy.Rows.Add(loai.MaLoaiMon, loai.TenLoaiMon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu loại món: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu chưa chọn dòng nào trong DataGridView
                if (dgvCategogy.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn loại món cần sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá trị từ các TextBox
                int maLoaiMon;
                string tenLoaiMon = txtTenLoaiMon.Text.Trim();

                // Kiểm tra nhập liệu
                if (string.IsNullOrEmpty(txtMaLoaiMon.Text) || string.IsNullOrEmpty(tenLoaiMon))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ mã loại món và tên loại món.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtMaLoaiMon.Text, out maLoaiMon))
                {
                    MessageBox.Show("Mã loại món phải là số.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra nếu mã loại món có tồn tại trong cơ sở dữ liệu
                var loaiMon = context.LoaiMons.FirstOrDefault(lm => lm.MaLoaiMon == maLoaiMon);
                if (loaiMon == null)
                {
                    MessageBox.Show("Không tìm thấy loại món với mã này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra tên loại món mới có trùng với loại món khác không
                var tenLoaiMonTrung = context.LoaiMons.Any(lm => lm.TenLoaiMon.Equals(tenLoaiMon, StringComparison.OrdinalIgnoreCase) && lm.MaLoaiMon != maLoaiMon);
                if (tenLoaiMonTrung)
                {
                    MessageBox.Show("Tên loại món đã tồn tại. Vui lòng chọn tên khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin loại món
                loaiMon.TenLoaiMon = tenLoaiMon;
                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                // Cập nhật lại dữ liệu hiển thị
                LoadCategoryData();

                // Reset các TextBox
                txtMaLoaiMon.Clear();
                txtTenLoaiMon.Clear();

                MessageBox.Show("Cập nhật loại món thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa loại món: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }

}
