using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly
{
    public class ChiTietHoaDon
    {
        public string TenMon { get; set; }  // Tên món ăn
        public int SoLuong { get; set; }    // Số lượng
        public decimal GiaTien { get; set; } // Giá tiền
        public decimal ThanhTien => SoLuong * GiaTien; // Thành tiền

        public DataTable CreateDataTable()
        {
            // Tạo DataTable để chứa thông tin món ăn
            DataTable dt = new DataTable("HoaDon");

            // Thêm các cột vào DataTable
            dt.Columns.Add("TenMon", typeof(string));  // Tên món ăn
            dt.Columns.Add("SoLuong", typeof(int));    // Số lượng
            dt.Columns.Add("GiaTien", typeof(decimal)); // Giá tiền
            dt.Columns.Add("ThanhTien", typeof(decimal)); // Thành tiền (SoLuong * GiaTien)
            dt.Columns.Add("QRCodePath", typeof(string)); // Đường dẫn mã QR

            return dt;
        }
    }
}
