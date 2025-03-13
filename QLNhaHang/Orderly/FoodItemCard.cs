using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Orderly
{
    public partial class FoodItemCard : UserControl
    {
        public FoodItemCard()
        {
            InitializeComponent();
        }
        // Phương thức này để set dữ liệu vào từng label trên UserControl
        public void SetData(int id, string name, string category, decimal price, string imagePath)
        {
            lblID.Text = $"ID: {id}";
            lblName.Text = name;
            lblCategoryID.Text = $"Loại: {category}";
            lblPrice.Text = $"{price:N0} đ";



            //MessageBox.Show($"Thư mục gốc của ứng dụng: {AppDomain.CurrentDomain.BaseDirectory}");

           

            // Kiểm tra nếu file ảnh tồn tại
            if (!string.IsNullOrEmpty(imagePath))
            {
                // Lấy đường dẫn thư mục gốc của ứng dụng
                string basePath = AppDomain.CurrentDomain.BaseDirectory;

                // Tạo đường dẫn đầy đủ
                string fullImagePath = Path.Combine(basePath, imagePath);

                pbFoodImage.Image = Image.FromFile(fullImagePath);
            }
            else
            {
                pbFoodImage.Image = Properties.Resources.lyruou; // Ảnh mặc định nếu không có ảnh
            }
        }
    }
}
