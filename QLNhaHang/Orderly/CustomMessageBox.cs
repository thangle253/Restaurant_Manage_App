using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Orderly
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, string title = "Thông Báo")
        {
            InitializeComponent();

            // 🔹 Căn giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(40, 40, 40); // Màu nền tối
            this.Width = 400;
            this.Height = 200;

            // 🔹 Panel chứa nội dung
            Panel panelContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // 🔹 Label Tiêu đề
            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40
            };

            // 🔹 Label Nội dung
            Label lblMessage = new Label
            {
                Text = message,
                Font = new Font("Arial", 10),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            // 🔹 Button OK (Dùng Guna2)
            Guna2Button btnOK = new Guna2Button
            {
                Text = "OK",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.DeepSkyBlue,
                Size = new Size(100, 40),
                Anchor = AnchorStyles.Bottom,
                Location = new Point((this.Width - 100) / 2, this.Height - 70) // Căn giữa theo form
            };

            // 🔹 Sự kiện Click cho nút OK
            btnOK.Click += (s, e) => { this.Close(); };

            // 🔹 Thêm vào Panel
            panelContainer.Controls.Add(lblMessage);
            panelContainer.Controls.Add(btnOK);

            // 🔹 Thêm vào Form
            this.Controls.Add(lblTitle);
            this.Controls.Add(panelContainer);

            // 🔹 Đưa nút OK lên trên cùng để không bị che
            btnOK.BringToFront();
        }

        public static void ShowMessage(string message, string title = "Thông Báo")
        {
            CustomMessageBox msgBox = new CustomMessageBox(message, title);
            msgBox.ShowDialog();
        }
    }
}
