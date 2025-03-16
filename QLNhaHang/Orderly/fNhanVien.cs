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
        public fNhanVien()
        {
            InitializeComponent();
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
    }
}
