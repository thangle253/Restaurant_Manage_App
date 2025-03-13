using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orderly.Model;

namespace Orderly
{
    public partial class Revenus : Form
    {
        public Revenus()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ DateTimePicker
            DateTime fromDate = dateTime1.Value.Date;
            DateTime toDate = dateTime2.Value.Date;

            try
            {
                using (var context = new QLNhaHangDB())
                {
                    // Lấy dữ liệu thống kê trong khoảng ngày
                    var thongKeData = context.ThongKes
                                             .Where(tk => tk.Ngay >= fromDate && tk.Ngay <= toDate)
                                             .Select(tk => new
                                             {
                                                 tk.MaThongKe,
                                                 Ban = tk.BanAn.TenBan,
                                                 tk.Ngay,
                                                 tk.SoLuongMon,
                                                 tk.TongTien
                                             })
                                             .ToList();

                    // Đổ dữ liệu vào DataGridView
                    dgvThongKe.Rows.Clear();
                    foreach (var item in thongKeData)
                    {
                        dgvThongKe.Rows.Add(item.MaThongKe, item.Ban, item.Ngay.ToString("dd/MM/yyyy"), item.SoLuongMon, item.TongTien);
                    }

                    // Thông báo nếu không có dữ liệu
                    if (!thongKeData.Any())
                    {
                        MessageBox.Show("Không có dữ liệu thống kê trong khoảng ngày đã chọn.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message);
            }
        }

       
    }
}
