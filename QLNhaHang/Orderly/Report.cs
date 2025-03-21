using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;
using System.Drawing;


namespace Orderly
{
    public partial class Report : Form
    {
        private int maDonHang;

        public Report(int maDonHang)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Không cho resize bất thường
            this.Size = new Size(650, 700); // Đặt kích thước form lớn hơn
            this.maDonHang = maDonHang;

        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {

                // ✅ Khởi tạo đối tượng ReportBill
                ReportBill reportBill = new ReportBill(maDonHang);

                // ✅ Lấy dữ liệu từ Entity Framework
                DataTable dt = reportBill.ConvertToDataTable();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Load Crystal Report
                ReportDocument rpt = new ReportDocument();
                string reportPath = System.IO.Path.Combine(Application.StartupPath, "Bill.rpt");


                rpt.Load(reportPath);

                rpt.SetDataSource(dt);

                // ✅ Hiển thị báo cáo
                crtrptBill.ReportSource = rpt;
                crtrptBill.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None; // Ẩn thanh bên trái
                crtrptBill.Dock = DockStyle.Fill; // ReportViewer mở rộng toàn bộ form
                crtrptBill.Zoom(75); // Đặt mức Zoom là 100%



                crtrptBill.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message + "\nStackTrace: " + ex.StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
