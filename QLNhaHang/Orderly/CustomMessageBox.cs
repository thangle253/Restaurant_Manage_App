using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Orderly
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, string title = "Thông Báo") // 🛠️ Thêm 2 tham số vào constructor
        {
            InitializeComponent();

            // 🔹 Căn giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;

            // 🔹 Tùy chỉnh giao diện
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(40, 40, 40); // Màu nền tối
            this.Width = 400;
            this.Height = 200;

            // 🔹 Label Tiêu đề
            Label lblTitle = new Label
            {
                Text = title,  // 🛠️ Dùng tham số title
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40
            };

            // 🔹 Label Nội dung
            Label lblMessage = new Label
            {
                Text = message, // 🛠️ Dùng tham số message
                Font = new Font("Arial", 10),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            // 🔹 Button OK (Dùng Guna)
            Guna2Button btnOK = new Guna2Button
            {
                Text = "OK",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.DeepSkyBlue,
                Size = new Size(100, 40),
                Location = new Point((this.Width - 100) / 2, 140)
            };
            btnOK.Click += (s, e) => { this.Close(); };

            // 🔹 Thêm vào Form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblMessage);
            this.Controls.Add(btnOK);
        }

        public static void ShowMessage(string message, string title = "Thông Báo")
        {
            CustomMessageBox msgBox = new CustomMessageBox(message, title);
            msgBox.ShowDialog();
        }
    }
}
