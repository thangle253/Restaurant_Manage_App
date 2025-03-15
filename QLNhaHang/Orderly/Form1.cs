using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Orderly
{
    public partial class Form1 : Form
    {
        private FormApp formApp; // Biến lưu instance của FormApp

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void lblClearText_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassWord.Clear();
            txtUserName.Focus();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát ứng dụng?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát ứng dụng hoàn toàn
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = chkShow.Checked ? '\0' : '*';
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
                e.SuppressKeyPress = true; // Ngăn âm báo phím Enter
            }
        }

        private void PerformLogin()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                // **1️⃣ Kiểm tra tài khoản hợp lệ**
                string loginQuery = "SELECT Type FROM Login WHERE Username=@username AND Password=@password";
                int userType = -1;

                using (SqlCommand cmd = new SqlCommand(loginQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassWord.Text.Trim());

                    object loginResult = cmd.ExecuteScalar();
                    if (loginResult != null)
                    {
                        userType = Convert.ToInt32(loginResult);
                        Session.CurrentUsername = txtUserName.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserName.Clear();
                        txtPassWord.Clear();
                        txtUserName.Focus();
                        return;
                    }
                }

                // **2️⃣ Lấy `EmployeeID` từ bảng Employees bằng `Username`**
                string employeeQuery = "SELECT EmployeeID FROM Employees WHERE Username = @username";
                using (SqlCommand cmd = new SqlCommand(employeeQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", Session.CurrentUsername);
                    object empResult = cmd.ExecuteScalar();
                    if (empResult != null)
                    {
                        Session.EmployeeID = Convert.ToInt32(empResult);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin nhân viên! Hãy kiểm tra lại tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // **3️⃣ Cập nhật hoặc tạo phiên đăng nhập**
                string checkUserSessionQuery = "SELECT COUNT(*) FROM UserSession WHERE Username=@username";
                int sessionCount = 0;
                using (SqlCommand checkCmd = new SqlCommand(checkUserSessionQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@username", Session.CurrentUsername);
                    sessionCount = (int)checkCmd.ExecuteScalar();
                }

                if (sessionCount > 0)
                {
                    string updateQuery = "UPDATE UserSession SET SessionTime = GETDATE() WHERE Username = @username";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue("@username", Session.CurrentUsername);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertQuery = "INSERT INTO UserSession (Username, SessionTime) VALUES (@username, GETDATE())";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@username", Session.CurrentUsername);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                // **4️⃣ Mở form tương ứng với quyền**
                if (userType == 1) // Admin
                {
                    if (formApp == null || formApp.IsDisposed)
                    {
                        formApp = new FormApp(this);
                    }
                    formApp.Show();
                }
                else // Nhân viên
                {
                    fNhanVien formNhanVien = new fNhanVien();
                    formNhanVien.Show();
                }

                this.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Đảm bảo thoát hoàn toàn ứng dụng
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassWord.Focus(); // Chuyển con trỏ sang ô mật khẩu khi nhấn Enter
                e.SuppressKeyPress = true; // Ngăn âm báo phím Enter
            }
        }
    }
}
