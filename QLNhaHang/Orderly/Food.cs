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
using System.Data.Entity;
namespace Orderly
{
    public partial class Food : Form
    {
        private QLNhaHangDB context; // Khai báo DbContext
        
        public Food()
        {
            InitializeComponent();
            context = new QLNhaHangDB(); // Khởi tạo DbContext
        }

        private void Food_Load(object sender, EventArgs e)
        {
            LoadFoodCards(); // Gọi phương thức để load dữ liệu vào card

            try
            {
                // Lấy danh sách loại món từ cơ sở dữ liệu
                var loaiMonList = context.LoaiMons.ToList();

                // Đổ dữ liệu vào ComboBox
                cmbLoai.DataSource = loaiMonList;
                cmbLoai.DisplayMember = "TenLoaiMon"; // Hiển thị tên loại món
                cmbLoai.ValueMember = "MaLoaiMon";    // Lấy giá trị là Mã Loại Món

                // Tải toàn bộ món ăn ban đầu
                var foodList = context.MonAns.ToList();
                dgvFood.Rows.Clear();
                foreach (var food in foodList)
                {
                    dgvFood.Rows.Add(food.MaMon, food.TenMon, food.MaLoaiMon, food.GiaTien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void LoadFoodCards()
        {
            flpFoodList.Controls.Clear(); // Xóa tất cả card cũ

            var foodList = context.MonAns.Include(f => f.LoaiMon).ToList();

            foreach (var food in foodList)
            {
                FoodItemCard card = new FoodItemCard();

                // Gọi phương thức SetData để gán dữ liệu lên từng label trong UserControl
                card.SetData(food.MaMon, food.TenMon, food.LoaiMon.TenLoaiMon, food.GiaTien,food.HinhAnh);

                flpFoodList.Controls.Add(card);
            }
        }



        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy Mã Loại Món được chọn trong ComboBox
                var selectedLoai = (LoaiMon)cmbLoai.SelectedItem;
                if (selectedLoai != null)
                {
                    int maLoaiMon = selectedLoai.MaLoaiMon;

                    // Lọc danh sách món ăn theo Mã Loại Món
                    var filteredFoodList = context.MonAns
                                                   .Where(ma => ma.MaLoaiMon == maLoaiMon)
                                                   .ToList();

                    // Đổ dữ liệu vào DataGridView
                    dgvFood.Rows.Clear();
                    foreach (var food in filteredFoodList)
                    {
                        dgvFood.Rows.Add(food.MaMon, food.TenMon, food.MaLoaiMon, food.GiaTien);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng nhấn vào một ô hợp lệ (không phải header)
                if (e.RowIndex >= 0 && dgvFood.Rows[e.RowIndex].Cells["ColID"].Value != null)
                {
                    // Lấy giá trị từ các ô trong dòng được chọn
                    string maMon = dgvFood.Rows[e.RowIndex].Cells["ColID"].Value.ToString();
                    string tenMon = dgvFood.Rows[e.RowIndex].Cells["ColName"].Value?.ToString();
                    string maLoaiMon = dgvFood.Rows[e.RowIndex].Cells["ColCategoryID"].Value?.ToString();
                    decimal giaTien = Convert.ToDecimal(dgvFood.Rows[e.RowIndex].Cells["ColPrice"].Value);

                    // Gán giá trị cho các TextBox
                    txtMaMon.Text = maMon;
                    txtTenMon.Text = tenMon;
                    txtGiaTien.Text = giaTien.ToString("N0"); // Định dạng giá tiền đúng kiểu

                    // Gán giá trị cho ComboBox
                    if (int.TryParse(maLoaiMon, out int parsedMaLoaiMon))
                    {
                        cmbLoai.SelectedValue = parsedMaLoaiMon;
                    }
                    else
                    {
                        MessageBox.Show("Mã loại món không hợp lệ.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý sự kiện: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra tính hợp lệ của dữ liệu
                if (string.IsNullOrWhiteSpace(txtMaMon.Text) ||
                    string.IsNullOrWhiteSpace(txtTenMon.Text) ||
                    cmbLoai.SelectedValue == null ||
                    string.IsNullOrWhiteSpace(txtGiaTien.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm món!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra Mã Món chỉ chứa số
                if (!int.TryParse(txtMaMon.Text.Trim(), out int maMon))
                {
                    MessageBox.Show("Mã món ăn phải là số và không chứa ký tự đặc biệt hoặc khoảng trắng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Loại bỏ định dạng " VND" và dấu chấm trước khi kiểm tra giá tiền
                string giaTienText = txtGiaTien.Text.Replace(".", "");
                if (!decimal.TryParse(giaTienText, out decimal giaTien) || giaTien <= 0)
                {
                    MessageBox.Show("Giá tiền phải là một số hợp lệ lớn hơn 0!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu từ các trường nhập liệu
                string tenMon = txtTenMon.Text;
                int maLoaiMon = (int)cmbLoai.SelectedValue;

                // Kiểm tra món ăn đã tồn tại chưa
                var existingMon = context.MonAns.FirstOrDefault(m => m.MaMon == maMon);
                if (existingMon != null)
                {
                    MessageBox.Show("Mã món đã tồn tại! Vui lòng nhập mã khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng món ăn mới
                var newMon = new MonAn
                {
                    MaMon = maMon,
                    TenMon = tenMon,
                    MaLoaiMon = maLoaiMon,
                    GiaTien = giaTien
                };

                // Thêm món ăn vào cơ sở dữ liệu
                context.MonAns.Add(newMon);
                context.SaveChanges();

                // Hiển thị thông báo và cập nhật lại danh sách món ăn
                MessageBox.Show("Thêm món mới thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFoodData(); // Phương thức để load lại dữ liệu món ăn vào dgvFood

                // Xóa các trường nhập liệu sau khi thêm
                txtMaMon.Clear();
                txtTenMon.Clear();
                txtGiaTien.Clear();
                cmbLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadFoodData()
        {
            try
            {
                // Lấy danh sách món ăn từ cơ sở dữ liệu
                var foodList = context.MonAns.ToList();

                // Xóa các dòng hiện có trong DataGridView
                dgvFood.Rows.Clear();

                // Thêm từng món ăn vào DataGridView
                foreach (var food in foodList)
                {
                    dgvFood.Rows.Add(food.MaMon, food.TenMon, food.MaLoaiMon, food.GiaTien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu món ăn: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã chọn dòng nào trong DataGridView chưa
                if (dgvFood.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin món ăn từ dòng được chọn
                DataGridViewRow selectedRow = dgvFood.SelectedRows[0];
                int maMon = int.Parse(selectedRow.Cells[0].Value.ToString());
                string tenMon = selectedRow.Cells[1].Value.ToString();

                // Hiển thị thông báo xác nhận
                DialogResult confirmResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa món ăn \"{tenMon}\" (Mã: {maMon})?",
                    "Xác Nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Tìm món ăn trong cơ sở dữ liệu
                    var monAn = context.MonAns.FirstOrDefault(m => m.MaMon == maMon);
                    if (monAn != null)
                    {
                        // Xóa món ăn khỏi cơ sở dữ liệu
                        context.MonAns.Remove(monAn);
                        context.SaveChanges();

                        // Hiển thị thông báo và cập nhật lại danh sách món ăn
                        MessageBox.Show("Xóa món ăn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFoodData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy món ăn cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không xóa được món ăn vì đang có món trong Order !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã chọn dòng nào trong DataGridView chưa
                if (dgvFood.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn món ăn cần sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin từ các trường nhập liệu
                if (string.IsNullOrWhiteSpace(txtMaMon.Text) ||
                    string.IsNullOrWhiteSpace(txtTenMon.Text) ||
                    cmbLoai.SelectedValue == null ||
                    string.IsNullOrWhiteSpace(txtGiaTien.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi sửa món!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra tính hợp lệ của Mã Món
                if (!int.TryParse(txtMaMon.Text.Trim().Replace(",", ""), out int maMon))
                {
                    MessageBox.Show("Mã món ăn phải là số và không chứa ký tự đặc biệt hoặc khoảng trắng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra món ăn có đang được sử dụng trong đơn hàng chưa thanh toán không
                var ordersWithFood = context.DonHangs
                    .Where(dh => dh.TrangThai == "Đã Đặt" && dh.ChiTietDonHangs.Any(ct => ct.MaMon == maMon))
                    .Select(dh => dh.MaDonHang)  // Lấy mã đơn hàng
                    .ToList();

                if (ordersWithFood.Any())
                {
                    string orderList = string.Join(", ", ordersWithFood);  // Danh sách mã đơn hàng
                    MessageBox.Show($"Không thể sửa món ăn này vì món đã có trong các đơn hàng đã đặt: {orderList}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin món ăn
                var monAn = context.MonAns.FirstOrDefault(m => m.MaMon == maMon);
                if (monAn == null)
                {
                    MessageBox.Show("Không tìm thấy món ăn cần sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra và xử lý giá tiền
                if (!decimal.TryParse(txtGiaTien.Text.Replace(",", "").Replace(".", ""), out decimal giaTien))
                {
                    MessageBox.Show("Giá tiền không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin món ăn
                monAn.TenMon = txtTenMon.Text;
                monAn.MaLoaiMon = (int)cmbLoai.SelectedValue;
                monAn.GiaTien = giaTien;

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();

                // Hiển thị thông báo và tải lại danh sách món ăn
                MessageBox.Show("Sửa thông tin món ăn thành công! Danh sách món ăn đã được cập nhật.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFoodData();

                // Xóa các trường nhập liệu sau khi sửa
                txtMaMon.Clear();
                txtTenMon.Clear();
                txtGiaTien.Clear();
                cmbLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa món ăn: {ex.Message}\n{ex.StackTrace}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                // Đặt lại ComboBox về trạng thái mặc định (chẳng hạn "Khai Vị")
                cmbLoai.SelectedIndex = 0; // Giả sử trạng thái mặc định là "Khai Vị"

                // Tải lại tất cả các món ăn (bao gồm tất cả các loại)
                LoadFoodData();  // Gọi phương thức LoadFoodData mà không có lọc loại món
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên món ăn người dùng nhập vào từ TextBox txtTimKiem
                string searchTerm = txtTimKiem.Text.Trim().ToLower();

                // Kiểm tra nếu TextBox không trống
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    // Tải lại dữ liệu và tìm kiếm món ăn theo tên
                    LoadFoodData(searchTerm);
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, tải tất cả món ăn
                    LoadFoodData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm món ăn: " + ex.Message);
            }
        }
        private void LoadFoodData(string searchTerm = "")
        {
            try
            {
                // Lấy tất cả món ăn từ cơ sở dữ liệu
                var foodList = context.MonAns.Include(f => f.LoaiMon).ToList();


                // Nếu có từ khóa tìm kiếm, lọc danh sách món ăn theo tên món
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    foodList = foodList.Where(f => f.TenMon.ToLower().Contains(searchTerm)).ToList();
                }

                // Xóa các dòng cũ trước khi đổ dữ liệu mới
                dgvFood.Rows.Clear();

                // Duyệt qua danh sách món ăn và thêm vào DataGridView
                foreach (var food in foodList)
                {
                    dgvFood.Rows.Add(food.MaMon, food.TenMon, food.MaLoaiMon, food.GiaTien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {
            // Lưu vị trí con trỏ
            int cursorPosition = txtGiaTien.SelectionStart;

            // Loại bỏ định dạng cũ (bỏ dấu chấm)
            string rawText = txtGiaTien.Text.Replace(".", "");

            // Kiểm tra nếu là số hợp lệ
            if (decimal.TryParse(rawText, out decimal giaTien))
            {
                // Định dạng lại số theo kiểu xxx.xxx.xxx
                txtGiaTien.Text = giaTien.ToString("N0").Replace(",", ".");
                txtGiaTien.SelectionStart = txtGiaTien.Text.Length; // Đặt lại vị trí con trỏ
            }
            else
            {
                // Nếu không hợp lệ, giữ nguyên nội dung cũ
                txtGiaTien.Text = rawText;
            }
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
 }
