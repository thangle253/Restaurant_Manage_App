using System;
using System.Windows.Forms;
namespace Orderly
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.CurrentUsername))
            {
                MessageBox.Show("Không tìm thấy thông tin đăng nhập. Vui lòng đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmProFile profileForm = new frmProFile(Session.CurrentUsername);
            profileForm.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePasswordForm = new frmChangePassword();
            changePasswordForm.ShowDialog();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận khi người dùng muốn đăng xuất
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",   // Nội dung thông báo
                "Xác nhận thoát",                              // Tiêu đề của hộp thoại
                MessageBoxButtons.YesNo,                       // Các nút: Yes và No
                MessageBoxIcon.Question,                       // Biểu tượng câu hỏi
                MessageBoxDefaultButton.Button1                // Nút mặc định là Yes
            );

            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, thoát hoàn toàn ứng dụng
                Application.Exit();
            }
            else
            {
                // Nếu người dùng chọn No, không làm gì cả
                // Để lại chương trình như cũ, không thoát
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session.CurrentUsername))
            {
                MessageBox.Show("Không tìm thấy thông tin đăng nhập. Vui lòng đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmProFile profileForm = new frmProFile(Session.CurrentUsername);
            profileForm.ShowDialog();
        }

        private void btnChangePassWord_Click_1(object sender, EventArgs e)
        {
            frmChangePassword changePasswordForm = new frmChangePassword();
            changePasswordForm.ShowDialog();
        }
    }
}
