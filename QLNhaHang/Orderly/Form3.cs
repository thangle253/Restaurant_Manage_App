using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static iText.Kernel.Pdf.Colorspace.PdfDeviceCs;
using QRCoder;
using VietQRHelper;
using System.Timers;

namespace Orderly
{
    public partial class Form3: Form
    {
        private decimal soTien;
        private System.Timers.Timer timer;
        private bool thanhToanThanhCong = false;
        public Form3(decimal tien)
        {
            InitializeComponent();
            soTien = tien;
            GenerateQRCode();
            lblSoTien.Text = $"Số tài khoản: 0373611257\nNgân hàng: MBBANK \nSố tiền: {soTien:N0} VND";

            // Khởi động timer kiểm tra thanh toán mỗi 5 giây
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += KiemTraThanhToan;
            timer.AutoReset = true;
            timer.Start();
        }
        private void GenerateQRCode()
        {
            try
            {
                var qrPay = QRPay.InitVietQR(
                    bankBin: "970422", // Mã BIN của MB Bank
                    bankNumber: "0373611257", // Số tài khoản cố định
                    amount: soTien.ToString(),
                    purpose: "Thanh toán đơn hàng"
                );

                var content = qrPay.Build(); // Chuỗi QR

                // ✅ Tạo mã QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(4, Color.DarkBlue, Color.White, true);
                picQRCode.Image = qrImage; // Hiển thị mã QR trong PictureBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo mã QR: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void KiemTraThanhToan(object sender, ElapsedEventArgs e)
        {
            // Giả lập kiểm tra trạng thái thanh toán
            Random rnd = new Random();
            thanhToanThanhCong = rnd.Next(0, 5) == 1; // Xác suất 20% thanh toán thành công (thay bằng API thật)

            if (thanhToanThanhCong)
            {
                timer.Stop(); // Dừng kiểm tra nếu đã thanh toán
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi thanh toán thành công
                }));
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          
        }
    }
}
