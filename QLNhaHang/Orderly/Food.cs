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
using System.IO;

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
                card.SetData(food.MaMon, food.TenMon, food.LoaiMon.TenLoaiMon, food.GiaTien, food.HinhAnh);

                card.FoodSelected += FoodItemCard_OnFoodSelected;

                flpFoodList.Controls.Add(card);
            }
        }

        private void FoodItemCard_OnFoodSelected(object sender, EventArgs e)
        {
            if (sender is FoodItemCard selectedCard)
            {
                // Hiển thị thông tin món ăn lên giao diện bên phải
                txtMaMon.Text = selectedCard.foodID.ToString();
                txtTenMon.Text = selectedCard.foodName;
                cmbLoai.Text = selectedCard.foodType;
                txtGiaTien.Text = selectedCard.foodPrice.ToString("N0");

                // Hiển thị ảnh món ăn nếu có
                if (!string.IsNullOrEmpty(selectedCard.imagePath))
                {
                    string fullImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, selectedCard.imagePath);
                    if (File.Exists(fullImagePath))
                    {
                        pbImageFood.Image = Image.FromFile(fullImagePath);
                    }
                    else
                    {
                        pbImageFood.Image = null;
                    }
                }
                else
                {
                    pbImageFood.Image = null;
                }
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


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
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


        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Kiểm tra tính hợp lệ của dữ liệu nhập
                if (string.IsNullOrWhiteSpace(txtMaMon.Text) ||
                    string.IsNullOrWhiteSpace(txtTenMon.Text) ||
                    cmbLoai.SelectedValue == null ||
                    string.IsNullOrWhiteSpace(txtGiaTien.Text))
                {
                    CustomMessageBox.ShowMessage("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                // 🔹 Kiểm tra Mã Món là số
                if (!int.TryParse(txtMaMon.Text.Trim(), out int maMon))
                {
                    MessageBox.Show("Mã món ăn phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Loại bỏ dấu chấm, định dạng số tiền
                string giaTienText = txtGiaTien.Text.Replace(".", "");
                if (!decimal.TryParse(giaTienText, out decimal giaTien) || giaTien <= 0)
                {
                    MessageBox.Show("Giá tiền phải là một số hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Lấy dữ liệu từ các trường nhập liệu
                string tenMon = txtTenMon.Text;
                int maLoaiMon = (int)cmbLoai.SelectedValue;
                string imagePath = pbImageFood.Tag?.ToString(); // Lấy đường dẫn ảnh từ Tag

                // 🔹 Kiểm tra món ăn đã tồn tại chưa
                var existingMon = context.MonAns.FirstOrDefault(m => m.MaMon == maMon);
                if (existingMon != null)
                {
                    MessageBox.Show("Mã món đã tồn tại! Vui lòng nhập mã khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Kiểm tra xem có ảnh không
                string savedImagePath = ""; // Đường dẫn ảnh lưu trong DB
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    // 🔹 Lấy thư mục lưu ảnh trong thư mục ứng dụng
                    string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Food_Image");

                    // 🔹 Tạo thư mục nếu chưa có
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    // 🔹 Lấy tên file từ đường dẫn gốc
                    string fileName = Path.GetFileName(imagePath);

                    // 🔹 Tạo đường dẫn mới trong thư mục `Food_Image`
                    string newImagePath = Path.Combine(imagesFolder, fileName);

                    // 🔹 Copy ảnh vào thư mục `Food_Image`
                    File.Copy(imagePath, newImagePath, true);

                    // 🔹 Lưu đường dẫn tương đối vào database
                    savedImagePath = $"Food_Image\\{fileName}";
                }

                // 🔹 Tạo đối tượng món ăn mới
                var newMon = new MonAn
                {
                    MaMon = maMon,
                    TenMon = tenMon,
                    MaLoaiMon = maLoaiMon,
                    GiaTien = giaTien,
                    HinhAnh = savedImagePath // Lưu đường dẫn ảnh tương đối
                };

                // 🔹 Thêm vào DB và lưu thay đổi
                context.MonAns.Add(newMon);
                context.SaveChanges();

                // 🔹 Thêm món ăn mới vào DataGridView
                dgvFood.Rows.Add(newMon.MaMon, newMon.TenMon, newMon.MaLoaiMon, newMon.GiaTien);

                // 🔹 Tạo Card mới để hiển thị món ăn
                FoodItemCard newCard = new FoodItemCard();
                newCard.SetData(newMon.MaMon, newMon.TenMon, cmbLoai.Text, newMon.GiaTien, newMon.HinhAnh);
                newCard.FoodSelected += FoodItemCard_OnFoodSelected; // Lắng nghe sự kiện chọn món

                // 🔹 Thêm vào `FlowLayoutPanel` ở cuối danh sách
                flpFoodList.Controls.Add(newCard);
                flpFoodList.ScrollControlIntoView(newCard); // Cuộn xuống món mới thêm

                // 🔹 Xóa dữ liệu nhập sau khi thêm thành công
                txtMaMon.Clear();
                txtTenMon.Clear();
                txtGiaTien.Clear();
                pbImageFood.Image = null;
                pbImageFood.Tag = null;
                cmbLoai.SelectedIndex = 0;

                // 🔹 Hiển thị thông báo thành công
                MessageBox.Show("Thêm món mới thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Kiểm tra xem có món ăn nào được chọn không
                if (string.IsNullOrWhiteSpace(txtMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maMon = int.Parse(txtMaMon.Text);

                // 🔹 Hiển thị hộp thoại xác nhận
                DialogResult confirmResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa món ăn \"{txtTenMon.Text}\" (Mã: {maMon})?",
                    "Xác Nhận Xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                // 🔹 Tìm món ăn trong database
                var monAn = context.MonAns.FirstOrDefault(m => m.MaMon == maMon);
                if (monAn == null)
                {
                    MessageBox.Show("Không tìm thấy món ăn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Xóa ảnh nếu có
                if (!string.IsNullOrEmpty(monAn.HinhAnh))
                {
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, monAn.HinhAnh);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath); // Xóa ảnh trong thư mục
                    }
                }

                // 🔹 Xóa món ăn khỏi Database
                context.MonAns.Remove(monAn);
                context.SaveChanges();

                // 🔹 Xóa món ăn khỏi DataGridView
                foreach (DataGridViewRow row in dgvFood.Rows)
                {
                    if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()) == maMon)
                    {
                        dgvFood.Rows.Remove(row);
                        break;
                    }
                }

                // 🔹 Xóa `FoodItemCard` khỏi `FlowLayoutPanel`
                FoodItemCard cardToRemove = null;
                foreach (FoodItemCard card in flpFoodList.Controls)
                {
                    if (card.foodID == maMon)
                    {
                        cardToRemove = card;
                        break;
                    }
                }

                if (cardToRemove != null)
                {
                    flpFoodList.Controls.Remove(cardToRemove);
                    cardToRemove.Dispose(); // Giải phóng bộ nhớ
                }

                // 🔹 Xóa thông tin trên giao diện
                txtMaMon.Clear();
                txtTenMon.Clear();
                txtGiaTien.Clear();
                pbImageFood.Image = null;
                pbImageFood.Tag = null;
                cmbLoai.SelectedIndex = 0;

                // 🔹 Hiển thị thông báo thành công
                MessageBox.Show("Xóa món ăn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa món ăn: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Kiểm tra xem có món ăn nào được chọn không
                if (string.IsNullOrWhiteSpace(txtMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn món ăn cần sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maMon = int.Parse(txtMaMon.Text);

                // 🔹 Tìm món ăn trong database
                var monAn = context.MonAns.FirstOrDefault(m => m.MaMon == maMon);
                if (monAn == null)
                {
                    MessageBox.Show("Không tìm thấy món ăn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Lấy dữ liệu mới từ giao diện
                string tenMon = txtTenMon.Text;
                int maLoaiMon = (int)cmbLoai.SelectedValue;
                string giaTienText = txtGiaTien.Text.Replace(".", "");
                if (!decimal.TryParse(giaTienText, out decimal giaTien) || giaTien <= 0)
                {
                    MessageBox.Show("Giá tiền không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Xử lý cập nhật ảnh mới nếu có
                string newImagePath = pbImageFood.Tag?.ToString();
                string savedImagePath = monAn.HinhAnh; // Đường dẫn cũ

                if (!string.IsNullOrEmpty(newImagePath) && File.Exists(newImagePath) && newImagePath != savedImagePath)
                {
                    // 🔹 Lấy thư mục lưu ảnh trong thư mục ứng dụng
                    string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Food_Image");

                    // 🔹 Tạo thư mục nếu chưa có
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    // 🔹 Lấy tên file từ đường dẫn gốc
                    string fileName = Path.GetFileName(newImagePath);

                    // 🔹 Tạo đường dẫn mới trong thư mục `Food_Image`
                    string finalImagePath = Path.Combine(imagesFolder, fileName);

                    // 🔹 Xóa ảnh cũ nếu có
                    if (!string.IsNullOrEmpty(savedImagePath))
                    {
                        string oldImageFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, savedImagePath);
                        if (File.Exists(oldImageFullPath))
                        {
                            File.Delete(oldImageFullPath);
                        }
                    }

                    // 🔹 Copy ảnh mới vào thư mục `Food_Image`
                    File.Copy(newImagePath, finalImagePath, true);

                    // 🔹 Lưu đường dẫn tương đối vào database
                    savedImagePath = $"Food_Image\\{fileName}";
                }

                // 🔹 Cập nhật dữ liệu trong Database
                monAn.TenMon = tenMon;
                monAn.MaLoaiMon = maLoaiMon;
                monAn.GiaTien = giaTien;
                monAn.HinhAnh = savedImagePath;

                context.SaveChanges();

                // 🔹 Cập nhật dữ liệu trong DataGridView
                foreach (DataGridViewRow row in dgvFood.Rows)
                {
                    if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()) == maMon)
                    {
                        row.Cells[1].Value = tenMon;
                        row.Cells[2].Value = maLoaiMon;
                        row.Cells[3].Value = giaTien;
                        break;
                    }
                }

                // 🔹 Cập nhật `FoodItemCard` trong `FlowLayoutPanel`
                foreach (FoodItemCard card in flpFoodList.Controls)
                {
                    if (card.foodID == maMon)
                    {
                        card.SetData(maMon, tenMon, cmbLoai.Text, giaTien, savedImagePath);
                        break;
                    }
                }

                // 🔹 Xóa thông tin nhập sau khi sửa xong
                txtMaMon.Clear();
                txtTenMon.Clear();
                txtGiaTien.Clear();
                pbImageFood.Image = null;
                pbImageFood.Tag = null;
                cmbLoai.SelectedIndex = 0;

                // 🔹 Hiển thị thông báo thành công
                MessageBox.Show("Sửa món ăn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa món ăn: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái hiện tại của dgvFood
            if (dgvFood.Visible)
            {
                // Nếu DataGridView đang hiển thị, ẩn nó và hiện FlowLayoutPanel
                dgvFood.Visible = false;
                flpFoodList.Visible = true;
            }
            else
            {
                // Nếu đang hiển thị FlowLayoutPanel, ẩn nó và hiện DataGridView
                dgvFood.Visible = true;
                flpFoodList.Visible = false;
            }
        }
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Ảnh món ăn (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImageFood.Image = Image.FromFile(openFileDialog.FileName);
                pbImageFood.Tag = openFileDialog.FileName; // Lưu đường dẫn ảnh để sử dụng sau
            }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            string searchTerm = txbSearchFood.Text.Trim().ToLower(); // Lấy nội dung tìm kiếm và chuyển về chữ thường

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadFoodCards(); // Nếu ô tìm kiếm trống, load lại toàn bộ danh sách
                return;
            }

            // 🔹 Lấy danh sách món ăn từ database
            var foodList = context.MonAns.Include(f => f.LoaiMon).ToList();

            // 🔹 Dùng thuật toán tìm kiếm gần đúng (Approximate Search)
            var filteredFoods = foodList.Where(food =>
                food.MaMon.ToString().Contains(searchTerm) ||         // Tìm kiếm theo ID món
                food.TenMon.ToLower().Contains(searchTerm) ||         // Tìm kiếm theo Tên món
                food.LoaiMon.TenLoaiMon.ToLower().Contains(searchTerm) || // Tìm kiếm theo Loại món
                food.GiaTien.ToString().Contains(searchTerm)          // Tìm kiếm theo Giá tiền
            ).ToList();

            // 🔹 Cập nhật giao diện FlowLayoutPanel
            flpFoodList.Controls.Clear();

            foreach (var food in filteredFoods)
            {
                FoodItemCard card = new FoodItemCard();
                card.SetData(food.MaMon, food.TenMon, food.LoaiMon.TenLoaiMon, food.GiaTien, food.HinhAnh);
                card.FoodSelected += FoodItemCard_OnFoodSelected;

                flpFoodList.Controls.Add(card);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các ô nhập liệu
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtGiaTien.Clear();

            // Đặt lại ComboBox về mặc định nếu có dữ liệu
            if (cmbLoai.Items.Count > 0)
            {
                cmbLoai.SelectedIndex = 0;
            }

            // Xóa ảnh đang hiển thị
            pbImageFood.Image = null;
            pbImageFood.Tag = null;
        }

        private void flpFoodList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
