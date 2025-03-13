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

                // Kiểm tra tài khoản tồn tại trong bảng Login
                string query = "SELECT COUNT(*) FROM Login WHERE username=@username AND password=@password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassWord.Text.Trim());

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Lưu username vào session
                        Session.CurrentUsername = txtUserName.Text.Trim();

                        // Kiểm tra xem Username đã tồn tại trong bảng UserSession chưa
                        string checkUserSessionQuery = "SELECT COUNT(*) FROM UserSession WHERE Username=@username";
                        using (SqlCommand checkCmd = new SqlCommand(checkUserSessionQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                            int sessionCount = (int)checkCmd.ExecuteScalar();

                            if (sessionCount > 0)
                            {
                                // Nếu Username đã tồn tại, cập nhật thời gian đăng nhập
                                string updateQuery = "UPDATE UserSession SET SessionTime = GETDATE() WHERE Username = @username";
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                                {
                                    updateCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Nếu Username chưa tồn tại, thêm bản ghi mới vào UserSession
                                string insertQuery = "INSERT INTO UserSession (Username) VALUES (@username)";
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                                {
                                    insertCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Mở form ứng dụng chính (FormApp)
                        if (formApp == null || formApp.IsDisposed)
                        {
                            formApp = new FormApp(this);
                        }

                        formApp.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserName.Clear();
                        txtPassWord.Clear();
                        txtUserName.Focus();
                    }
                }

                con.Close();
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
