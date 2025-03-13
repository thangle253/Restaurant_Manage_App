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
            btnChoose.Click += BtnChoose_Click; // Bắt sự kiện chọn món

        }

        // 🔹 Tạo event để truyền dữ liệu khi chọn món
        public event EventHandler FoodSelected;

        // Các biến lưu thông tin món ăn
        public int foodID;
        public string foodName;
        public string foodType;
        public decimal foodPrice;
        public string imagePath;

        // 📌 Hiển thị event trong bảng Properties (Designer)
        [Browsable(true)]
        [Category("Food Events")]
        [Description("Sự kiện xảy ra khi người dùng chọn món ăn.")]
        public event EventHandler OnFoodSelected
        {
            add { FoodSelected += value; }
            remove { FoodSelected -= value; }
        }

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
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            // 🔹 Gọi event khi người dùng chọn món ăn
            FoodSelected?.Invoke(this, EventArgs.Empty);
        }


    }
}
