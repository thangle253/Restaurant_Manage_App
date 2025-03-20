using System;
using System.Collections.Generic;
using System.Linq;
using Orderly.Model;
using QRCoder;
using System.Drawing;
using System.Windows.Forms;
using VietQRHelper;
using System.Data;

namespace Orderly
{
    public class ReportBill
    {
        private int maDonHang;
        private decimal tongTien;
        private string qrCodePath;

        public ReportBill(int maDonHang)
        {
            this.maDonHang = maDonHang;
            this.tongTien = LayTongTien();
            this.qrCodePath = GenerateQRCode();
        }

        // ✅ Lấy danh sách món ăn từ database bằng Entity Framework
        public List<ChiTietHoaDon> LayChiTietHoaDon()
        {
            using (var context = new QLNhaHangDB())
            {
                return context.ChiTietDonHangs
                    .Where(ct => ct.MaDonHang == maDonHang)
                    .Select(ct => new ChiTietHoaDon
                    {
                        TenMon = ct.MonAn.TenMon,
                        SoLuong = ct.SoLuong,
                        GiaTien = ct.MonAn.GiaTien
                    }).ToList();
            }
        }



        // ✅ Lấy tổng tiền của đơn hàng
        public decimal LayTongTien()
        {
            using (var context = new QLNhaHangDB())
            {
                return context.DonHangs
                    .Where(dh => dh.MaDonHang == maDonHang)
                    .Select(dh => dh.TongTien ?? 0)
                    .FirstOrDefault();
            }
        }

        // ✅ Chuyển dữ liệu từ List<> sang DataTable để dùng trong Crystal Report
        public DataTable ConvertToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenMon", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("GiaTien", typeof(decimal));
            dt.Columns.Add("ThanhTien", typeof(decimal));
            dt.Columns.Add("QRCodePath", typeof(string));

            foreach (var item in LayChiTietHoaDon())
            {
                dt.Rows.Add(item.TenMon, item.SoLuong, item.GiaTien, item.SoLuong * item.GiaTien, qrCodePath);
            }

            return dt;
        }

        // ✅ Hàm lấy đường dẫn QR Code để dùng trong Crystal Report
        public string GetQRCodePath()
        {
            return qrCodePath;
        }

        // ✅ Tạo mã QR thanh toán VietQR và lưu vào file ảnh
        private string GenerateQRCode()
        {
            try
            {
                var qrPay = QRPay.InitVietQR(
                    bankBin: "970422",
                    bankNumber: "0373611257",
                    amount: tongTien.ToString(), // 🔥 Sửa lỗi: Dùng tongTien thay vì soTien
                    purpose: "Thanh toán đơn hàng"
                );

                var content = qrPay.Build(); // Chuỗi QR cần tạo

                // ✅ Tạo mã QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(10);

                // ✅ Lưu QR code vào file ảnh
                string qrFilePath = System.IO.Path.GetTempPath() + "QRCode.png";
                qrImage.Save(qrFilePath, System.Drawing.Imaging.ImageFormat.Png);
                return qrFilePath; // Trả về đường dẫn file QR
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo mã QR: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
