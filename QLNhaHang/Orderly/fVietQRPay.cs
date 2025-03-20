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
    public partial class fVietQRPay: Form
    {
        private decimal soTien;
        private System.Timers.Timer timer;
        private bool thanhToanThanhCong = false;
        public fVietQRPay(decimal tien)
        {
            InitializeComponent();
            soTien = tien;
            GenerateQRCode();
            lblSoTien.Text = $"Số tài khoản: 0373611257\nNgân hàng: MBBANK \nSố tiền: {soTien:N0} VND";
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
      
        private void Form3_Load(object sender, EventArgs e)
        {
          
        }
    }
}
