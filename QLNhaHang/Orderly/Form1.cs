using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
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
            "Bạn có chắc chắn muốn thoát ứng dụng ?",
            "Thông báo",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               this.Close();
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
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                // 1️⃣ **Kiểm tra tài khoản hợp lệ trước**
                string loginQuery = "SELECT Type FROM Login WHERE username=@username AND password=@password";
                int userType = -1; // Mặc định không hợp lệ

                using (SqlCommand cmd = new SqlCommand(loginQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassWord.Text.Trim());

                    object loginResult = cmd.ExecuteScalar();
                    if (loginResult != null)
                    {
                        userType = Convert.ToInt32(loginResult); // Lưu loại tài khoản
                        Session.CurrentUsername = txtUserName.Text.Trim(); // Lưu tên đăng nhập vào Session
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserName.Clear();
                        txtPassWord.Clear();
                        txtUserName.Focus();
                        return; // ❌ Thoát khỏi hàm nếu đăng nhập không hợp lệ
                    }
                }

                // 2️⃣ **Lấy `EmployeeID` từ `Employees` sau khi xác thực tài khoản**
                string employeeQuery = "SELECT EmployeeID FROM Employees WHERE FullName = @username";
                using (SqlCommand cmd = new SqlCommand(employeeQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", Session.CurrentUsername);
                    object empResult = cmd.ExecuteScalar();
                    Session.EmployeeID = empResult != null ? Convert.ToInt32(empResult) : -1; // Lưu EmployeeID
                }

                // 3️⃣ **Cập nhật hoặc tạo phiên đăng nhập trong bảng `UserSession`**
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

                // 4️⃣ **Mở form tương ứng với quyền**
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
                    fNhanVien formNhanVien = new fNhanVien(Session.EmployeeID); // ✅ Truyền EmployeeID khi mở Form nhân viên
                    formNhanVien.Show();
                }

                this.Hide(); // Ẩn form đăng nhập
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
