using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orderly.Model2;
using System.Data.SqlClient;
namespace Orderly
{
    public partial class Account : Form
    {

        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng DbContext
                QuanLyTaiKhoanDB context = new QuanLyTaiKhoanDB();

                // Lấy danh sách tài khoản từ cơ sở dữ liệu
                List<Login> listLogin = context.Logins.ToList();

                // Đổ dữ liệu vào ComboBox và DataGridView
                FillTypeCombobox();
                BindAccountGrid(listLogin);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void FillTypeCombobox()
        {
            // Đổ dữ liệu vào ComboBox cmbType (0 và 1)
            cmbType.Items.Clear();  // Xóa tất cả các mục cũ trong ComboBox
            cmbType.Items.Add(0);   // Thêm giá trị 0
            cmbType.Items.Add(1);   // Thêm giá trị 1
            cmbType.SelectedIndex = 0;  // Chọn mặc định là 0
        }

        private void BindAccountGrid(List<Login> listLogin)
        {
            dgvAccount.Rows.Clear();
            dgvAccount.Columns.Clear(); // Xóa các cột cũ để tránh trùng lặp

            // Thêm cột vào DataGridView
            dgvAccount.Columns.Add("ColUserName", "Username"); // Cột Tên đăng nhập
            dgvAccount.Columns.Add("ColType", "Type");         // Cột Type

            // Thêm dữ liệu vào DataGridView
            foreach (var login in listLogin)
            {
                int index = dgvAccount.Rows.Add();
                dgvAccount.Rows[index].Cells["ColUserName"].Value = login.Username; // Tên đăng nhập
                dgvAccount.Rows[index].Cells["ColType"].Value = login.Type; // Loại tài khoản
            }

        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu không phải click vào dòng tiêu đề (dòng đầu tiên)
                if (e.RowIndex >= 0)
                {
                    // Lấy dữ liệu từ cột ColUserName và ColType
                    string username = dgvAccount.Rows[e.RowIndex].Cells["ColUserName"].Value.ToString();
                    string type = dgvAccount.Rows[e.RowIndex].Cells["ColType"].Value.ToString();

                    // Đưa dữ liệu vào các điều khiển tương ứng
                    txtUserName.Text = username;

                    // Gán giá trị vào cmbType mà không thay đổi SelectedIndex
                    cmbType.Text = type;  // Truyền giá trị "0" hoặc "1" vào ComboBox

                    Employee_Detail empDetailForm = new Employee_Detail(username);
                    empDetailForm.ShowDialog();
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
                // Lấy tên tài khoản đăng nhập hiện tại từ Session
                string username = Session.CurrentUsername; // Lấy tên người dùng hiện tại từ Session
                bool isAdmin = CheckIfAdmin(username); // Kiểm tra xem tài khoản có phải Admin không

                if (!isAdmin)
                {
                    MessageBox.Show("Bạn chưa đủ quyền để thực hiện chức năng này.");
                    return;
                }

                // Nếu tài khoản là Admin, tiếp tục xử lý thêm tài khoản mới
                string newUsername = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                int type = (cmbType.SelectedItem.ToString() == "0") ? 0 : 1;  // Kiểm tra giá trị trong ComboBox để xác định loại tài khoản

                if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
                    return;
                }

                // Tạo đối tượng DbContext và kết nối với SQL Server
                using (QuanLyTaiKhoanDB context = new QuanLyTaiKhoanDB())
                {
                    // Kiểm tra xem tài khoản đã tồn tại chưa
                    var existingUser = context.Logins.FirstOrDefault(u => u.Username == newUsername);
                    if (existingUser != null)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại.");
                        return;
                    }

                    // Tạo đối tượng Login mới
                    Login newLogin = new Login
                    {
                        Username = newUsername,
                        Password = password,
                        Type = type
                    };

                    // Thêm vào cơ sở dữ liệu
                    context.Logins.Add(newLogin);
                    context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                    // Cập nhật lại DataGridView
                    List<Login> listLogin = context.Logins.ToList();
                    BindAccountGrid(listLogin);  // Gọi lại phương thức để cập nhật dữ liệu

                    MessageBox.Show("Thêm tài khoản thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        // Kiểm tra xem tài khoản có phải là Admin không
        private bool CheckIfAdmin(string username)
        {
            string connectionString = "Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT Type FROM Login WHERE Username = @username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int type = Convert.ToInt32(reader["Type"]);
                            return type == 1; // Nếu Type = 1 thì là Admin
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản trong hệ thống.");
                            return false;
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên tài khoản đăng nhập hiện tại từ Session
                string currentUsername = Session.CurrentUsername; // Lấy tên người dùng hiện tại từ Session
                bool isAdmin = CheckIfAdmin(currentUsername); // Kiểm tra xem tài khoản có phải Admin không

                if (!isAdmin)
                {
                    MessageBox.Show("Bạn chưa đủ quyền để thực hiện chức năng này.");
                    return;
                }

                // Lấy tên tài khoản cần xóa từ TextBox
                string usernameToDelete = txtUserName.Text.Trim();

                if (string.IsNullOrEmpty(usernameToDelete))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa.");
                    return;
                }

                // Kiểm tra nếu tài khoản cần xóa là tài khoản hiện đang đăng nhập
                if (usernameToDelete == currentUsername)
                {
                    // Xác nhận đặc biệt cho tài khoản đang đăng nhập
                    DialogResult confirmLogout = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa tài khoản ĐANG ĐĂNG NHẬP này không? Bạn sẽ bị đăng xuất ngay lập tức.",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmLogout == DialogResult.No)
                    {
                        return; // Không làm gì nếu người dùng chọn "No"
                    }
                }
                else
                {
                    // Xác nhận thông thường cho tài khoản khác
                    DialogResult confirmDelete = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa tài khoản '{usernameToDelete}' không?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmDelete == DialogResult.No)
                    {
                        return; // Không làm gì nếu người dùng chọn "No"
                    }
                }

                // Tạo đối tượng DbContext và kết nối với SQL Server
                using (QuanLyTaiKhoanDB context = new QuanLyTaiKhoanDB())
                {
                    // Tìm tài khoản cần xóa
                    var userToDelete = context.Logins.FirstOrDefault(u => u.Username == usernameToDelete);
                    if (userToDelete == null)
                    {
                        MessageBox.Show("Tài khoản không tồn tại.");
                        return;
                    }

                    // Xóa tài khoản
                    context.Logins.Remove(userToDelete);
                    context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                    // Cập nhật lại DataGridView
                    List<Login> listLogin = context.Logins.ToList();
                    BindAccountGrid(listLogin); // Gọi lại phương thức để cập nhật dữ liệu

                    MessageBox.Show("Xóa tài khoản thành công.");

                    // Kiểm tra nếu tài khoản bị xóa là tài khoản đang đăng nhập
                    if (usernameToDelete == currentUsername)
                    {
                        // Đăng xuất và đóng ứng dụng
                        MessageBox.Show("Bạn đã xóa tài khoản đang đăng nhập. Hệ thống sẽ đăng xuất.");
                        Application.Exit(); // Thoát khỏi ứng dụng
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tên tài khoản đăng nhập hiện tại từ Session
                string username = Session.CurrentUsername; // Lấy tên người dùng hiện tại từ Session
                bool isAdmin = CheckIfAdmin(username); // Kiểm tra xem tài khoản có phải Admin không

                if (!isAdmin)
                {
                    MessageBox.Show("Bạn chưa đủ quyền để thực hiện chức năng này.");
                    return;
                }

                // Lấy thông tin từ các điều khiển
                string usernameToUpdate = txtUserName.Text.Trim();
                string newPassword = txtPassword.Text.Trim();
                int newType = (cmbType.SelectedItem.ToString() == "0") ? 0 : 1;

                if (string.IsNullOrEmpty(usernameToUpdate) || string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.");
                    return;
                }

                // Tạo đối tượng DbContext và kết nối với SQL Server
                using (QuanLyTaiKhoanDB context = new QuanLyTaiKhoanDB())
                {
                    // Tìm tài khoản cần sửa
                    var userToUpdate = context.Logins.FirstOrDefault(u => u.Username == usernameToUpdate);
                    if (userToUpdate == null)
                    {
                        MessageBox.Show("Tài khoản không tồn tại.");
                        return;
                    }

                    // Cập nhật thông tin
                    userToUpdate.Password = newPassword;
                    userToUpdate.Type = newType;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    // Cập nhật lại DataGridView
                    List<Login> listLogin = context.Logins.ToList();
                    BindAccountGrid(listLogin); // Gọi lại phương thức để cập nhật dữ liệu

                    MessageBox.Show("Cập nhật tài khoản thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message);
            }
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
                    }
    }
}
