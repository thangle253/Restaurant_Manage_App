using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Orderly.Model;
using Orderly.UC;
namespace Orderly
{
    public partial class Order : Form
    {
        private QLNhaHangDB context; // Khai báo biến DbContext
        private int selectedTable = -1;  // Lưu bàn đã chọn
        private List<MonAn> listMonAn; // Danh sách món ăn
        public Order()
        {
            InitializeComponent();
            context = new QLNhaHangDB(); // Khởi tạo DbContext
            LoadTables();
        }

        private void LoadTables()
        {
            pnlMenuHeader.Visible = false; // Ẩn panel khi quay lại Order
            flpTable.Controls.Clear(); // Xóa bàn cũ trước khi load lại
            using (var context = new QLNhaHangDB())
            {
                var banAnList = context.BanAns.ToList();
                foreach (var ban in banAnList)
                {
                    var uc = new ucTable
                    {
                        TableID = ban.MaBan,
                        TableName = ban.TenBan,
                        Status = ban.TrangThai
                    };

                    uc.SetTableData(ban.MaBan, ban.TenBan, ban.TrangThai, Image.FromFile("C:\\Users\\APPLE\\Documents\\Restaurant_Manage_App\\QLNhaHang\\Orderly\\Resources\\table_Oderr.png"));

                    uc.TableSelected += Uc_TableSelected;
                    flpTable.Controls.Add(uc);
                }
            }
        }

        private void Uc_TableSelected(object sender, EventArgs e)
        {
            var clickedTable = sender as ucTable;
            if (clickedTable != null)
            {
                // Nếu đã có bàn được chọn trước đó, bỏ chọn bàn cũ
                if (selectedTable != -1 && selectedTable != clickedTable.TableID)
                {
                    var oldTable = flpTable.Controls.OfType<ucTable>()
                        .FirstOrDefault(t => t.TableID == selectedTable);
                    if (oldTable != null)
                    {
                        oldTable.IsSelected = false;
                        oldTable.UpdateTableColor(); // ✅ Cập nhật màu bàn cũ
                    }
                }

                // Cập nhật bàn mới
                selectedTable = clickedTable.TableID;
                clickedTable.IsSelected = true;
                clickedTable.UpdateTableColor(); // ✅ Cập nhật màu bàn mới
                clickedTable.Invalidate(); // ✅ Vẽ lại để phản ánh thay đổi màu
                                          
                lblTableName.Text = $"Bàn {selectedTable}";
                // ✅ Cập nhật tên bàn trong label
                LoadOrderForTable(selectedTable);
            }
        }
        private Dictionary<int, List<Tuple<string, int, decimal, decimal>>> tableOrders = new Dictionary<int, List<Tuple<string, int, decimal, decimal>>>();
        private void LoadOrderForTable(int tableID)
        {
            dgvOderBill.Rows.Clear(); // Xóa dữ liệu cũ trước khi hiển thị

            if (tableOrders.ContainsKey(tableID))
            {
                foreach (var item in tableOrders[tableID])
                {
                    dgvOderBill.Rows.Add(Properties.Resources.tomi, item.Item1, item.Item2, item.Item3, item.Item4);
                }
            }

            TinhTongTien(); // Cập nhật tổng tiền
        }





        private void Order_Load(object sender, EventArgs e)
        {
            try
            {

                LoadTables();
                SetupDataGridView(); // Khởi tạo DataGridView



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlMenuHeader.Visible = true;


            LoadMenuItems(); // Load danh sách món ăn
        }


        private void LoadMenuItems()
        {

            flpTable.Controls.Clear(); // Xóa các item cũ

            using (var context = new QLNhaHangDB())
            {
                var foodList = context.MonAns.Include(f => f.LoaiMon).ToList();

                if (foodList.Count == 0)
                {
                    MessageBox.Show("Không có món ăn nào trong database!");
                }

                foreach (var food in foodList)
                {
                    FoodItemCard card = new FoodItemCard();
                    card.SetData(food.MaMon, food.TenMon, food.LoaiMon.TenLoaiMon, food.GiaTien, food.HinhAnh);
                    
                    card.FoodSelected -=FoodItem_FoodSelected;

                    card.FoodSelected +=FoodItem_FoodSelected;

                    flpTable.Controls.Add(card); // Thêm vào FlowLayoutPanel
                }
            }
        }

        private void FoodItem_FoodSelected(object sender, FoodItemCard.FoodEventArgs e)
        {
            if (selectedTable == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddFoodToTable(selectedTable, e.FoodName, e.FoodPrice);
        }

        private void AddFoodToTable(int tableID, string tenMon, decimal giaTien)
        {
            if (!tableOrders.ContainsKey(tableID))
            {
                tableOrders[tableID] = new List<Tuple<string, int, decimal, decimal>>();
            }

            // ✅ Duyệt danh sách để cập nhật số lượng mà không xóa mục cũ
            for (int i = 0; i < tableOrders[tableID].Count; i++)
            {
                if (tableOrders[tableID][i].Item1 == tenMon)
                {
                    int newQuantity = tableOrders[tableID][i].Item2 + 1;
                    decimal newTotal = newQuantity * giaTien;

                    // ✅ Cập nhật trực tiếp số lượng mà không xóa rồi thêm lại
                    tableOrders[tableID][i] = Tuple.Create(tenMon, newQuantity, giaTien, newTotal);

                    LoadOrderForTable(tableID);
                    return; // Thoát luôn để tránh thêm món mới lần thứ 2
                }
            }

            // ✅ Nếu món chưa có, thêm mới với số lượng 1
            tableOrders[tableID].Add(Tuple.Create(tenMon, 1, giaTien, giaTien));

            LoadOrderForTable(tableID);
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvOderBill.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            // 🏆 Hiển thị tổng số tiền trên Label
            lblTotalAmount.Text = $"{tongTien:N0} VND";
        }






        private void txbSearch_TextChanged(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetupDataGridView()
        {
            // Xóa tất cả cột cũ (nếu có)
            dgvOderBill.Columns.Clear();
            dgvOderBill.AllowUserToAddRows = false;
            dgvOderBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOderBill.RowTemplate.Height = 40; // Tăng chiều cao mỗi dòng

            // 👉 1. Cột icon xóa (thùng rác)
            DataGridViewImageColumn colXoa = new DataGridViewImageColumn();
            colXoa.Image = Properties.Resources.tomi; // Hình ảnh từ Resources (Bạn phải thêm icon vào Resources)
            colXoa.Name = "ColXoa";
            colXoa.HeaderText = "";
            colXoa.Width = 10; // Đặt chiều rộng nhỏ
            dgvOderBill.Columns.Add(colXoa);

            // 👉 2. Cột tên món
            DataGridViewTextBoxColumn colTenMon = new DataGridViewTextBoxColumn();
            colTenMon.Name = "TenMon";
            colTenMon.HeaderText = "Món ăn";
            dgvOderBill.Columns.Add(colTenMon);

            // 👉 3. Cột số lượng
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.Name = "SoLuong";
            colSoLuong.HeaderText = "SL";
            colSoLuong.Width = 50;
            dgvOderBill.Columns.Add(colSoLuong);

            // 👉 4. Cột giá tiền
            DataGridViewTextBoxColumn colGiaTien = new DataGridViewTextBoxColumn();
            colGiaTien.Name = "GiaTien";
            colGiaTien.HeaderText = "Giá";
            dgvOderBill.Columns.Add(colGiaTien);

            // 👉 5. Cột thành tiền
            DataGridViewTextBoxColumn colThanhTien = new DataGridViewTextBoxColumn();
            colThanhTien.Name = "ThanhTien";
            colThanhTien.HeaderText = "Tổng";
            dgvOderBill.Columns.Add(colThanhTien);
        }

        private void dgvOderBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Cột icon xóa
            {
                if (selectedTable == -1)
                {
                    MessageBox.Show("Vui lòng chọn bàn trước khi xóa món!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!tableOrders.ContainsKey(selectedTable) || tableOrders[selectedTable].Count == 0)
                {
                    MessageBox.Show("Không có món nào để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tenMon = dgvOderBill.Rows[e.RowIndex].Cells["TenMon"].Value.ToString();

                // ✅ Xóa món khỏi danh sách của bàn
                tableOrders[selectedTable].RemoveAll(item => item.Item1 == tenMon);

                // ✅ Xóa món khỏi `DataGridView`
                dgvOderBill.Rows.RemoveAt(e.RowIndex);

                // ✅ Cập nhật tổng tiền
                TinhTongTien();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (selectedTable == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🏆 Kiểm tra xem bàn có món ăn nào không
            if (!tableOrders.ContainsKey(selectedTable) || tableOrders[selectedTable].Count == 0)
            {
                MessageBox.Show("Không có món nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 🔥 Xác nhận trước khi xóa toàn bộ món ăn
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa toàn bộ món ăn trong đơn hàng?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // 🧹 Xóa toàn bộ món ăn của bàn đang chọn
                tableOrders[selectedTable].Clear();

                // 🧹 Xóa toàn bộ món trong DataGridView
                dgvOderBill.Rows.Clear();

                // ✅ Cập nhật tổng tiền về 0 VND bằng cách gọi lại `TinhTongTien()`
                TinhTongTien();
            }
        }

    }
}
