using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orderly
{
    public partial class fNhanVien : Form
    {
        private Form1 _form1; // Biến tham chiếu đến Form1
                              // Constructor mới nhận tham chiếu của Form1
        public fNhanVien(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }
        public void LoadFormNhanVien(Form form)
        {
            if (this.pnlMainContent.Controls.Count > 0)
            {
                this.pnlMainContent.Controls.RemoveAt(0); // Xóa form cũ nếu có
            }

            form.TopLevel = false;
            form.Dock = DockStyle.Fill; // Form con tự động khớp với panel
            form.FormBorderStyle = FormBorderStyle.None;
            form.Size = pnlMainContent.Size; // Set kích thước form con bằng panel

            this.pnlMainContent.Controls.Add(form);
            this.pnlMainContent.Tag = form;

            form.Show();
        }
        private void btnCheckInOut_Click(object sender, EventArgs e)
        {
            LoadFormNhanVien(new fAttendance(Session.EmployeeID));
        }
        private void btnEmployeeInfo_Click(object sender, EventArgs e)
        {
            LoadFormNhanVien(new Employee_Infor(Session.EmployeeID));
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            LoadFormNhanVien(new Order());
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {

        }

        

        

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hiển thị lại Form1 nếu nó đã bị ẩn
            if (_form1 != null && !_form1.IsDisposed)
            {
                _form1.Show();
            }

            // Đóng FormApp
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
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
    }
}
