using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Orderly.Model;


namespace Orderly
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string currentUsername = Session.CurrentUsername; // Lấy username hiện tại
            string currentPassword = txtPassWord.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtPasswordAgain.Text.Trim();

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới không khớp. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LoginDoAn;Integrated Security=True;TrustServerCertificate=True"))
            {
                con.Open();

                // Kiểm tra mật khẩu hiện tại
                string checkQuery = "SELECT COUNT(*) FROM Login WHERE Username = @username AND Password = @password";
                using (SqlCommand cmd = new SqlCommand(checkQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", currentUsername);
                    cmd.Parameters.AddWithValue("@password", currentPassword);

                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Cập nhật mật khẩu mới
                string updateQuery = "UPDATE Login SET Password = @newPassword WHERE Username = @username";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cmd.Parameters.AddWithValue("@username", currentUsername);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mật khẩu đã được thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi thay đổi mật khẩu
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form nếu người dùng hủy
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            // Hiển thị tên người dùng hiện tại trong txtUser
            txtUser.Text = Session.CurrentUsername; // Giả sử `Session.CurrentUsername` lưu trữ tên người dùng hiện tại
            txtUser.ReadOnly = true; // Đặt thuộc tính ReadOnly thành true để không thể chỉnh sửa
        }
    }
}
