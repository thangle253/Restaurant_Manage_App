using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Orderly
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        // Phương thức để nhận dữ liệu từ form gọi
        public void SetReportData(string tenBan, decimal tongTien, List<ChiTietHoaDon> chiTietHoaDonList)
        {
            // Đặt tham số cho báo cáo
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("TenBan", tenBan),
                new ReportParameter("TongTien", tongTien.ToString("N0") + " VND")
            };

            reportViewer1.LocalReport.SetParameters(parameters);

            // Đặt dữ liệu cho báo cáo
            var reportDataSource = new ReportDataSource("DataSet1", chiTietHoaDonList);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Làm mới báo cáo
            reportViewer1.RefreshReport();
        }
        private void Report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

     
    }
}
