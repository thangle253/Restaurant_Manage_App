using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orderly.UC
{
    public partial class ucTable : UserControl
    {
        public int TableID { get; set; }
        private string _tableName;
        private string _status;
        private bool _isSelected = false; // Trạng thái bàn có đang được chọn không
        public Panel PanelTable
        {
            get { return panelTable; }
        }


        public string TableName
        {
            get => _tableName;
            set
            {
                _tableName = value;
                lblTableName.Text = value;
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                UpdateTableColor();
                Invalidate(); // ✅ Gọi lại Paint để vẽ viền
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                UpdateTableColor();
            }
        }

        public event EventHandler TableSelected;

        public ucTable()
        {
            InitializeComponent();
            this.Click += UcTable_Click;  // Bắt sự kiện Click trên UserControl
            picTable.Click += UcTable_Click;
            lblTableName.Click += UcTable_Click;
            panelTable.Paint += guna2Panel1_Paint;

            panelTable.Paint += PanelTable_Paint;


        }

        private void UcTable_Click(object sender, EventArgs e)
        {

            if (!_isSelected)  // Chỉ chọn nếu chưa được chọn
            {
                TableSelected?.Invoke(this, EventArgs.Empty); // Gửi sự kiện lên Form chính
            }
        }

        public void UpdateTableColor()
        {
            if (IsSelected)
            {
                panelTable.BackColor = Color.LightGreen; // ✅ Giữ màu xanh nhưng không làm mất viền
            }
            else
            {
                if (_status == "Trống")
                    panelTable.BackColor = Color.White;
                else if (_status == "Da dat")
                    panelTable.BackColor = Color.Crimson;
            }

            panelTable.Invalidate(); // ✅ Vẽ lại UI để hiển thị viền bo tròn chính xác
        }




        public void SetTableData(int id, string name, string status, Image img)
        {
            TableID = id;
            TableName = name;
            Status = status;
            picTable.Image = img;
        }
        
        






        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 1; // Độ dày viền
            int borderRadius = 10; // Độ cong góc
            Color borderColor = Color.Black; // Màu viền

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // ⚠️ Tạo một khoảng trống nhỏ để viền không bị cắt mất
            Rectangle rect = new Rectangle(borderWidth / 2, borderWidth / 2,
                                           panelTable.Width - borderWidth - 1,
                                           panelTable.Height - borderWidth - 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, borderRadius * 2, borderRadius * 2, 180, 90); // Trên trái
                path.AddArc(rect.Right - borderRadius * 2, rect.Y, borderRadius * 2, borderRadius * 2, 270, 90); // Trên phải
                path.AddArc(rect.Right - borderRadius * 2, rect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90); // Dưới phải
                path.AddArc(rect.X, rect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90); // Dưới trái
                path.CloseFigure();

                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void PanelTable_Paint(object sender, PaintEventArgs e)
        {
            int borderRadius = 10;  // ✅ Độ cong viền
            int borderWidth = 0;     // ✅ Độ dày viền

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, panelTable.Width - 1, panelTable.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, borderRadius * 2, borderRadius * 2, 180, 90); // Trên trái
                path.AddArc(rect.Right - borderRadius * 2, rect.Y, borderRadius * 2, borderRadius * 2, 270, 90); // Trên phải
                path.AddArc(rect.Right - borderRadius * 2, rect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 0, 90); // Dưới phải
                path.AddArc(rect.X, rect.Bottom - borderRadius * 2, borderRadius * 2, borderRadius * 2, 90, 90); // Dưới trái
                path.CloseFigure();

                using (Pen pen = new Pen(Color.Black, borderWidth))  // ✅ Viền màu đen
                {
                    g.DrawPath(pen, path); // ✅ Vẽ đường viền
                }

                panelTable.Region = new Region(path);  // ✅ Cắt vùng panel theo viền bo tròn
            }
        }


        private void ucTable_Load(object sender, EventArgs e)
        {

        }

        private void lblTableName_Click_1(object sender, EventArgs e)
        {

        }

        private void picTable_Click_2(object sender, EventArgs e)
        {

        }

    }
}

