using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public event EventHandler TableSelected;

        public ucTable()
        {
            InitializeComponent();
            this.Click += UcTable_Click;  // Bắt sự kiện Click trên UserControl
            picTable.Click += UcTable_Click;
            lblTableName.Click += UcTable_Click;
        }

        private void UcTable_Click(object sender, EventArgs e)
        {
            TableSelected?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateTableColor()
        {
            if (_status == "Trống")
                this.BackColor = Color.White; // Bàn trống: viền Trắng

            else if (_status == "Đã đặt")
                this.BackColor = Color.Crimson; // Bàn đã đặt: viền đỏ

            // Đảm bảo PictureBox có viền rõ ràng
            picTable.BorderStyle = BorderStyle.None; // Ẩn viền mặc định
        }

        public void SetTableData(int id, string name, string status, Image img)
        {
            TableID = id;
            TableName = name;
            Status = status;
            picTable.Image = img;
        }


        private void picTable_Click(object sender, EventArgs e) { }
        private void lblTableName_Click(object sender, EventArgs e) { }
    }
}
