using System;
using System.Drawing;
using System.Windows.Forms;
namespace Orderly
{
    public partial class FormApp : Form
    {
        private Form1 _form1; // Biến tham chiếu đến Form1
                              // Constructor mới nhận tham chiếu của Form1
 
        public FormApp(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1; // Lưu tham chiếu của Form1
        }
        // Constructor không tham số (giúp tạo FormApp khi không cần tham số Form1)

        private void lblThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn thoát ứng dụng ?",
        "Thông báo",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát hoàn toàn ứng dụng
            }
        }

        private void lblQuayLai_Click(object sender, EventArgs e)
        {
            // Hiển thị lại Form1 nếu nó đã bị ẩn
            if (_form1 != null && !_form1.IsDisposed)
            {
                _form1.Show();
            }

            // Đóng FormApp
            this.Close();
        }
        private void ScaleControls(Form formCon, Size pnlSize, Size formSize)
        {
            // Tính tỷ lệ kích thước giữa form chính và form con
            float scaleX = (float)pnlSize.Width / formSize.Width;
            float scaleY = (float)pnlSize.Height / formSize.Height;

            // Duyệt qua tất cả các điều khiển trong form con và thay đổi kích thước của chúng theo tỷ lệ
            foreach (Control control in formCon.Controls)
            {
                control.Width = (int)(control.Width * scaleX);
                control.Height = (int)(control.Height * scaleY);
                control.Left = (int)(control.Left * scaleX);
                control.Top = (int)(control.Top * scaleY);
            }
        }
        public void loadform(object Form)
        {
            if (this.pnlGiaoDienChin.Controls.Count > 0)
            {
                this.pnlGiaoDienChin.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill; // Form con tự động khớp kích thước với panel
            f.FormBorderStyle = FormBorderStyle.None; // Ẩn viền của form con
            f.Size = pnlGiaoDienChin.Size; // Đặt kích thước form con bằng panel

            this.pnlGiaoDienChin.Controls.Add(f);
            this.pnlGiaoDienChin.Tag = f;

            // Phóng to tất cả các điều khiển trong form con
            ScaleControls(f, pnlGiaoDienChin.Size, f.Size);

            f.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            loadform(new Home());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            loadform(new Order());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            loadform(new Table());
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            loadform(new Food());
        }

        private void btnCategogy_Click(object sender, EventArgs e)
        {
            loadform(new Categogy());
        }

        private void btnRevenus_Click(object sender, EventArgs e)
        {
            loadform(new Revenus());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            loadform(new Account());
        }

        private void pnlGiaoDienChin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


