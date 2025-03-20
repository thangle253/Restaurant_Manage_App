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
        private Dictionary<int, List<Tuple<string, int, decimal, decimal>>> tableOrders = new Dictionary<int, List<Tuple<string, int, decimal, decimal>>>();
        // 🔹 Lưu danh sách món ăn của từng bàn để tránh mất dữ liệu khi load lại UI

        public Order()
        {
            InitializeComponent();
            context = new QLNhaHangDB(); // Khởi tạo DbContext
            LoadTables();
            LoadCategories();


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

                    uc.SetTableData(ban.MaBan, ban.TenBan, ban.TrangThai, Properties.Resources.table_Oderr);
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
                // ✅ Nếu đã có bàn được chọn trước đó
                if (selectedTable != -1 && selectedTable != clickedTable.TableID)
                {
                    using (var context = new QLNhaHangDB())
                    {
                        var currentTable = context.BanAns.Find(selectedTable);
                        if (currentTable != null && currentTable.TrangThai == "Da dat")
                        {
                            // 🔥 Nếu bàn cũ đang "Đã đặt", xóa sạch `dgvOderBill`
                            dgvOderBill.Rows.Clear();
                            TinhTongTien();
                        }
                    }

                    // ✅ Hủy chọn bàn cũ và cập nhật lại màu gốc
                    var oldTable = flpTable.Controls.OfType<ucTable>()
                        .FirstOrDefault(t => t.TableID == selectedTable);
                    if (oldTable != null)
                    {
                        oldTable.IsSelected = false;

                        // 🔥 Cập nhật lại màu theo trạng thái của bàn
                        using (var context = new QLNhaHangDB())
                        {
                            var previousTable = context.BanAns.Find(selectedTable);
                            if (previousTable != null)
                            {
                                oldTable.PanelTable.BackColor = (previousTable.TrangThai == "Da dat") ? Color.Red : Color.White;
                            }
                        }

                        oldTable.UpdateTableColor();
                    }
                }

                // ✅ Cập nhật bàn mới
                selectedTable = clickedTable.TableID;
                clickedTable.IsSelected = true;
                clickedTable.UpdateTableColor();
                clickedTable.Invalidate();

                lblTableName.Text = $"Bàn {selectedTable}";

                using (var context = new QLNhaHangDB())
                {
                    var newTable = context.BanAns.Find(selectedTable);
                    if (newTable != null && newTable.TrangThai == "Da dat")
                    {
                        // ✅ Nếu bàn mới đã đặt, hiển thị món ăn đã đặt
                        LoadOrderForTable(selectedTable);
                    }
                    else
                    {
                        // 🧹 Nếu bàn chưa đặt, xóa sạch `dgvOderBill`
                        dgvOderBill.Rows.Clear();
                        TinhTongTien();
                    }
                }
            }
        }

        private void LoadOrderForTable(int tableID)
        {
            dgvOderBill.Rows.Clear();

            using (var context = new QLNhaHangDB())
            {
                var order = context.DonHangs
                    .Where(dh => dh.MaBan == tableID && dh.TrangThai == "Da dat")
                    .OrderByDescending(dh => dh.NgayDat)
                    .FirstOrDefault();

                if (order != null)
                {
                    var chiTietList = context.ChiTietDonHangs.Where(ct => ct.MaDonHang == order.MaDonHang).ToList();

                    foreach (var chiTiet in chiTietList)
                    {
                        var food = context.MonAns.FirstOrDefault(m => m.MaMon == chiTiet.MaMon);
                        if (food == null) continue;

                        dgvOderBill.Rows.Add(null, food.TenMon, chiTiet.SoLuong, food.GiaTien, chiTiet.SoLuong * food.GiaTien);
                    }
                }
            }

            // ✅ Hiển thị dữ liệu từ `tableOrders`
            if (tableOrders.ContainsKey(tableID))
            {
                foreach (var item in tableOrders[tableID])
                {
                    bool exists = dgvOderBill.Rows.Cast<DataGridViewRow>().Any(row =>
                        row.Cells["TenMon"].Value != null && row.Cells["TenMon"].Value.ToString() == item.Item1);

                    if (!exists)
                    {
                        dgvOderBill.Rows.Add(null, item.Item1, item.Item2, item.Item3, item.Item4);
                    }
                }
            }

            TinhTongTien();
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
            lblHeaderTable.Visible = false; 
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
                    card.FoodSelected -= FoodItem_FoodSelected;
                    card.FoodSelected += FoodItem_FoodSelected;
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

            // ✅ Kiểm tra xem món đã có trong DataGridView chưa
            bool isUpdated = false;
            foreach (DataGridViewRow row in dgvOderBill.Rows)
            {
                if (row.Cells["TenMon"].Value != null && row.Cells["TenMon"].Value.ToString() == tenMon)
                {
                    // Nếu đã có -> Cập nhật số lượng
                    int currentQuantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    int newQuantity = currentQuantity + 1;
                    decimal newTotal = newQuantity * giaTien;

                    row.Cells["SoLuong"].Value = newQuantity;
                    row.Cells["ThanhTien"].Value = newTotal;

                    isUpdated = true;
                    break; // Ngừng vòng lặp ngay khi tìm thấy món
                }
            }

            for (int i = 0; i < tableOrders[tableID].Count; i++)
            {
                if (tableOrders[tableID][i].Item1 == tenMon)
                {
                    int newQuantity = tableOrders[tableID][i].Item2 + 1;
                    decimal newTotal = newQuantity * giaTien;

                    tableOrders[tableID][i] = Tuple.Create(tenMon, newQuantity, giaTien, newTotal);
                    isUpdated = true;
                    break;
                }
            }

        
            // ✅ Nếu món chưa có -> Thêm mới vào DataGridView
            if (!isUpdated)
            {
                dgvOderBill.Rows.Add(null, tenMon, 1, giaTien, giaTien);
                tableOrders[tableID].Add(Tuple.Create(tenMon, 1, giaTien, giaTien));

            }

            // ✅ Cập nhật tổng tiền
            TinhTongTien();
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
            colXoa.Image = Properties.Resources.TrashBin;
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

            // Cột FoodID (Ẩn)
            DataGridViewTextBoxColumn colFoodID = new DataGridViewTextBoxColumn();
            colFoodID.Name = "ColFoodID";  // Đây là tên cột bạn đang dùng
            colFoodID.HeaderText = "ID";
            colFoodID.Visible = false;  // Không hiển thị trên UI

            dgvOderBill.Columns.Add(colFoodID);
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

                if (dgvOderBill.Rows.Count == 0)
                {
                    MessageBox.Show("Không có món nào để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tenMon = dgvOderBill.Rows[e.RowIndex].Cells["TenMon"].Value.ToString();

                // ✅ Xóa món khỏi danh sách của bàn trong `tableOrders`
                if (tableOrders.ContainsKey(selectedTable))
                {
                    tableOrders[selectedTable].RemoveAll(item => item.Item1 == tenMon);
                }

                // ✅ Xóa món khỏi `dgvOderBill`
                dgvOderBill.Rows.RemoveAt(e.RowIndex);

                // ✅ Nếu không còn món nào trong bàn -> Xóa hết danh sách
                if (dgvOderBill.Rows.Count == 0)
                {
                    tableOrders.Remove(selectedTable);
                }

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

            // 🔥 Load lại để đảm bảo `dgvOderBill.Rows.Count` không bị lỗi
            LoadOrderForTable(selectedTable);

            if (dgvOderBill.Rows.Count == 0)
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

        private void btnTable_Click(object sender, EventArgs e)
        {
            pnlMenuHeader.Visible = false; // Ẩn menu trên cùng
            flpTable.Visible = true;  // Hiển thị danh sách bàn
            LoadTables(); // Load lại danh sách bàn

            // 🔥 Khi quay lại Table, nếu có bàn đã chọn trong lblTableName, đặt lại trạng thái
            if (int.TryParse(lblTableName.Text.Replace("Bàn ", ""), out int tableID))
            {
                selectedTable = tableID;

                // ✅ Tìm lại bàn trong danh sách và đặt màu nền xanh
                var selectedUcTable = flpTable.Controls.OfType<ucTable>().FirstOrDefault(t => t.TableID == selectedTable);
                if (selectedUcTable != null)
                {
                    selectedUcTable.IsSelected = true;
                    selectedUcTable.UpdateTableColor(); // Gọi hàm cập nhật UI
                }
            }
        }

        private void txbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // 🔹 Chỉ tìm khi ấn Enter
            {
                e.SuppressKeyPress = true; // 🔹 Ngăn tiếng *Beep* khi nhấn Enter

                string searchTerm = txbSearch.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadMenuItems(); // Nếu ô tìm kiếm trống, load lại toàn bộ danh sách
                    return;
                }

                // 🔹 Truy vấn trực tiếp trên database để giảm lag
                var filteredFoods = context.MonAns
                    .Include(f => f.LoaiMon)
                    .Where(food =>
                        food.MaMon.ToString().Contains(searchTerm) || // Tìm theo ID món
                        food.TenMon.ToLower().Contains(searchTerm) || // Tìm theo Tên món
                        food.LoaiMon.TenLoaiMon.ToLower().Contains(searchTerm) || // Tìm theo Loại món
                        food.GiaTien.ToString().Contains(searchTerm)) // Tìm theo Giá tiền
                    .AsNoTracking() // ✅ Tăng tốc bằng cách không tracking entity
                    .ToList();

                // 🏆 Giảm render UI bằng BeginUpdate/EndUpdate
                flpTable.SuspendLayout();
                flpTable.Controls.Clear();

                foreach (var food in filteredFoods)
                {
                    FoodItemCard card = new FoodItemCard();
                    card.SetData(food.MaMon, food.TenMon, food.LoaiMon.TenLoaiMon, food.GiaTien, food.HinhAnh);
                    card.FoodSelected -= FoodItem_FoodSelected;
                    card.FoodSelected += FoodItem_FoodSelected;

                    flpTable.Controls.Add(card);
                }

                flpTable.ResumeLayout();
            }
        }

        private void LoadCategories()
        {
            using (var context = new QLNhaHangDB())
            {
                var categories = context.LoaiMons.ToList();

                cbbCategory.DataSource = categories;
                cbbCategory.DisplayMember = "TenLoaiMon"; // Hiển thị tên danh mục
                cbbCategory.ValueMember = "MaLoaiMon"; // Giá trị là mã danh mục
                cbbCategory.SelectedIndex = -1; // Không chọn gì ban đầu
            }
        }
        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedItem != null)
            {
                var selectedCategory = (LoaiMon)cbbCategory.SelectedItem;
                int categoryId = selectedCategory.MaLoaiMon; // Lấy MaLoaiMon đúng cách
                nbrudNumber.Value = 1;
                LoadFoodItems(categoryId); // Load món ăn theo danh mục

            }
        }
        private void LoadFoodItems(int categoryId)
        {
            using (var context = new QLNhaHangDB())
            {
                var foods = context.MonAns
                    .Where(f => f.MaLoaiMon == categoryId) // Lọc theo danh mục đã chọn
                    .OrderBy(f => f.TenMon) // Sắp xếp theo tên
                    .ToList();

                // Gán danh sách vào combobox món ăn
                cbbFoodName.DataSource = foods;
                cbbFoodName.DisplayMember = "TenMon"; // Hiển thị tên món ăn
                cbbFoodName.ValueMember = "MaMon"; // Giá trị là mã món ăn
                cbbFoodName.SelectedIndex = -1; // Không chọn gì ban đầu
            }
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (selectedTable == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbFoodName.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nbrudNumber.Value < 1)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Lấy thông tin món ăn được chọn
            var selectedFood = (MonAn)cbbFoodName.SelectedItem;
            string foodName = selectedFood.TenMon;
            decimal price = selectedFood.GiaTien;
            int quantity = (int)nbrudNumber.Value;
            decimal totalPrice = quantity * price; // ✅ Tính tổng tiền

            // ✅ Đảm bảo `tableOrders[selectedTable]` tồn tại
            if (!tableOrders.ContainsKey(selectedTable))
            {
                tableOrders[selectedTable] = new List<Tuple<string, int, decimal, decimal>>();
            }

            bool isUpdated = false;

            // ✅ Cập nhật món trong `tableOrders`
            for (int i = 0; i < tableOrders[selectedTable].Count; i++)
            {
                if (tableOrders[selectedTable][i].Item1 == foodName)
                {
                    int newQuantity = tableOrders[selectedTable][i].Item2 + quantity;
                    decimal newTotal = newQuantity * price;

                    // ✅ Cập nhật dữ liệu trong `tableOrders`
                    tableOrders[selectedTable][i] = Tuple.Create(foodName, newQuantity, price, newTotal);
                    isUpdated = true;
                    break;
                }
            }

            // ✅ Nếu món chưa có trong `tableOrders`, thêm mới
            if (!isUpdated)
            {
                tableOrders[selectedTable].Add(Tuple.Create(foodName, quantity, price, totalPrice));
            }

            // ✅ Cập nhật `dgvOderBill` từ `tableOrders`
            LoadOrderForTable(selectedTable);
            nbrudNumber.Value = 1; // Reset số lượng
        }



        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedTable == -1)
                {
                    return;
                }


                LoadOrderForTable(selectedTable); // Đảm bảo dữ liệu cập nhật trước khi đặt món

                if (dgvOderBill.Rows.Count == 0)
                {
                    MessageBox.Show("Không có món nào trong danh sách đặt hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var context = new QLNhaHangDB())
                {
                    int newOrderID = context.DonHangs.Any() ? context.DonHangs.Max(dh => dh.MaDonHang) + 1 : 1;
                    DateTime orderDate = DateTime.Now;


                    var newOrder = new DonHang
                    {
                        MaDonHang = newOrderID,
                        MaBan = selectedTable,
                        NgayDat = orderDate,
                        TongTien = 0,
                        TrangThai = "Da dat"
                    };

                    context.DonHangs.Add(newOrder);
                    context.SaveChanges();

                    decimal totalAmount = 0;
                    int count = 0;

                    // ✅ Duyệt tất cả món trong dgvOderBill
                    foreach (DataGridViewRow row in dgvOderBill.Rows)
                    {
                        if (row.Cells["TenMon"].Value == null) continue;

                        string foodName = row.Cells["TenMon"].Value.ToString();
                        int quantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        decimal price = Convert.ToDecimal(row.Cells["GiaTien"].Value);
                        totalAmount += quantity * price;

                        // ✅ Lấy đúng MaMon từ database
                        var food = context.MonAns.FirstOrDefault(f => f.TenMon == foodName);
                        if (food == null)
                        {
                            continue;
                        }

                        var orderDetail = new ChiTietDonHang
                        {
                            MaChiTiet = context.ChiTietDonHangs.Any() ? context.ChiTietDonHangs.Max(ct => ct.MaChiTiet) + 1 + count : 1,
                            MaDonHang = newOrderID,
                            MaMon = food.MaMon,
                            SoLuong = quantity
                        };

                        context.ChiTietDonHangs.Add(orderDetail);
                        count++;

                    }

                    if (count == 0)
                    {
                        return;
                    }

                    // ✅ Cập nhật tổng tiền của đơn hàng
                    newOrder.TongTien = totalAmount;
                    context.SaveChanges();

                    // ✅ Cập nhật trạng thái bàn
                    var table = context.BanAns.FirstOrDefault(b => b.MaBan == selectedTable);
                    if (table != null)
                    {
                        table.TrangThai = "Da dat";
                        context.SaveChanges();
                    }

                    MessageBox.Show("Đơn hàng đã được đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadOrderForTable(selectedTable);
                    LoadTables();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

            string amountText = lblTotalAmount.Text.Replace(",", "").Replace(" VND", "").Trim();
            if (decimal.TryParse(amountText, out decimal soTien) && soTien > 0)
            {
                fVietQRPay formQR = new fVietQRPay(soTien);
                formQR.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalAmount.Focus();
            }

        }
    }
}