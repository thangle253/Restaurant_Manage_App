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
using iText.IO.Image;


namespace Orderly
{
    public partial class FoodItemCard : UserControl
    {
        public FoodItemCard()
        {
            InitializeComponent();
        }

       
        // Các biến lưu thông tin món ăn
        public int foodID;
        public string foodName;
        public string foodType;
        public decimal foodPrice;
        public string imagePath;

        // 📌 Hiển thị event trong bảng Properties (Designer)
        public event EventHandler<FoodEventArgs> FoodSelected;

        [Browsable(true)]
        [Category("Food Events")]
        [Description("Sự kiện xảy ra khi người dùng chọn món ăn.")]
        public event EventHandler<FoodEventArgs> OnFoodSelected
        {
            add { FoodSelected += value; }
            remove { FoodSelected -= value; }
        }
         //🔹 Tạo event đúng kiểu dữ liệu


        // Phương thức này để set dữ liệu vào từng label trên UserControl
        public void SetData(int id, string name, string category, decimal price, string imagePath)
        {
            // Lưu thông tin món ăn vào biến
            this.foodID = id;
            this.foodName = name;
            this.foodType = category;
            this.foodPrice = price;
            this.imagePath = imagePath;

            // Hiển thị thông tin món ăn lên giao diện
            lblID.Text = $"ID: {id}";
            lblName.Text = name;
            lblCategoryID.Text = $"Loại: {category}";
            lblPrice.Text = $"{price:N0} đ";

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

        private void FoodItemCard_Load(object sender, EventArgs e)
        {

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            // 🔹 Gọi event khi người dùng chọn món ăn
            FoodSelected?.Invoke(this, new FoodEventArgs(foodID, foodName, foodPrice));

        }

      
        // ✅ Định nghĩa EventArgs để chứa dữ liệu món ăn
        public class FoodEventArgs : EventArgs
        {
            public int FoodID { get; }
            public string FoodName { get; }
            public decimal FoodPrice { get; }

            public FoodEventArgs(int id, string name, decimal price)
            {
                FoodID = id;
                FoodName = name;
                FoodPrice = price;
            }
        }

        public void SetFoodData(int id, string name, decimal price)
        {
            this.foodID = id;
            this.foodName = name;
            this.foodPrice = price;

            lblName.Text = name;
            lblPrice.Text = $"{price:N0} đ";
        }



    }
}
