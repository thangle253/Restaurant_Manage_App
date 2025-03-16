namespace Orderly
{
    partial class Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.cmbMon = new System.Windows.Forms.ComboBox();
            this.numericUpDownSoLuong = new System.Windows.Forms.NumericUpDown();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.ColFoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntoMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbChonBanDoi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMenuHeader = new System.Windows.Forms.Panel();
            this.txbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.pnlMenuHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbLoai
            // 
            this.cmbLoai.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoai.Location = new System.Drawing.Point(1099, 115);
            this.cmbLoai.Margin = new System.Windows.Forms.Padding(5);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(437, 57);
            this.cmbLoai.TabIndex = 0;
            // 
            // cmbMon
            // 
            this.cmbMon.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMon.Location = new System.Drawing.Point(1017, 331);
            this.cmbMon.Margin = new System.Windows.Forms.Padding(5);
            this.cmbMon.Name = "cmbMon";
            this.cmbMon.Size = new System.Drawing.Size(437, 57);
            this.cmbMon.TabIndex = 1;
            // 
            // numericUpDownSoLuong
            // 
            this.numericUpDownSoLuong.BackColor = System.Drawing.Color.White;
            this.numericUpDownSoLuong.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSoLuong.ForeColor = System.Drawing.Color.White;
            this.numericUpDownSoLuong.Location = new System.Drawing.Point(1488, 242);
            this.numericUpDownSoLuong.Margin = new System.Windows.Forms.Padding(5);
            this.numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            this.numericUpDownSoLuong.Size = new System.Drawing.Size(282, 57);
            this.numericUpDownSoLuong.TabIndex = 3;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFoodName,
            this.ColQty,
            this.ColUnitPrice,
            this.ColIntoMoney});
            this.dgvOrder.Location = new System.Drawing.Point(1099, 456);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(5);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.Size = new System.Drawing.Size(707, 496);
            this.dgvOrder.TabIndex = 5;
            // 
            // ColFoodName
            // 
            this.ColFoodName.HeaderText = "FoodName";
            this.ColFoodName.MinimumWidth = 6;
            this.ColFoodName.Name = "ColFoodName";
            // 
            // ColQty
            // 
            this.ColQty.HeaderText = "Qty";
            this.ColQty.MinimumWidth = 6;
            this.ColQty.Name = "ColQty";
            // 
            // ColUnitPrice
            // 
            this.ColUnitPrice.HeaderText = "Unit Price";
            this.ColUnitPrice.MinimumWidth = 6;
            this.ColUnitPrice.Name = "ColUnitPrice";
            // 
            // ColIntoMoney
            // 
            this.ColIntoMoney.HeaderText = "Into Money";
            this.ColIntoMoney.MinimumWidth = 6;
            this.ColIntoMoney.Name = "ColIntoMoney";
            // 
            // cmbChonBanDoi
            // 
            this.cmbChonBanDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(202)))));
            this.cmbChonBanDoi.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChonBanDoi.FormattingEnabled = true;
            this.cmbChonBanDoi.Location = new System.Drawing.Point(1099, 1087);
            this.cmbChonBanDoi.Margin = new System.Windows.Forms.Padding(5);
            this.cmbChonBanDoi.Name = "cmbChonBanDoi";
            this.cmbChonBanDoi.Size = new System.Drawing.Size(248, 63);
            this.cmbChonBanDoi.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.label1.Location = new System.Drawing.Point(1091, 984);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 61);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Amount:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(1451, 990);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(5);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(355, 55);
            this.txtTongTien.TabIndex = 8;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(104)))), ((int)(((byte)(96)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(1561, 1079);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(5);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(245, 86);
            this.btnThanhToan.TabIndex = 10;
            this.btnThanhToan.Text = "Pay";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(2, 54);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(1089, 1175);
            this.flpTable.TabIndex = 13;
            // 
            // btnMenu
            // 
            this.btnMenu.BorderRadius = 10;
            this.btnMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenu.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(1102, 5);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(186, 57);
            this.btnMenu.TabIndex = 14;
            this.btnMenu.Text = "Menu";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1541, 331);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(210, 73);
            this.guna2Button1.TabIndex = 15;
            this.guna2Button1.Text = "Add Food";
            // 
            // pnlMenuHeader
            // 
            this.pnlMenuHeader.Controls.Add(this.txbSearch);
            this.pnlMenuHeader.Controls.Add(this.guna2Button2);
            this.pnlMenuHeader.Location = new System.Drawing.Point(5, 3);
            this.pnlMenuHeader.Name = "pnlMenuHeader";
            this.pnlMenuHeader.Size = new System.Drawing.Size(1086, 64);
            this.pnlMenuHeader.TabIndex = 17;
            // 
            // txbSearch
            // 
            this.txbSearch.BorderColor = System.Drawing.Color.Black;
            this.txbSearch.BorderRadius = 10;
            this.txbSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbSearch.DefaultText = "";
            this.txbSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.ForeColor = System.Drawing.Color.Black;
            this.txbSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txbSearch.IconLeft")));
            this.txbSearch.Location = new System.Drawing.Point(279, 4);
            this.txbSearch.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txbSearch.PlaceholderText = "                 Search in here";
            this.txbSearch.SelectedText = "";
            this.txbSearch.Size = new System.Drawing.Size(577, 56);
            this.txbSearch.TabIndex = 16;
            this.txbSearch.TextChanged += new System.EventHandler(this.txbSearch_TextChanged);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.DarkOrange;
            this.guna2Button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(19, 2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(195, 57);
            this.guna2Button2.TabIndex = 15;
            this.guna2Button2.Text = "Table";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1826, 1232);
            this.Controls.Add(this.pnlMenuHeader);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbChonBanDoi);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.numericUpDownSoLuong);
            this.Controls.Add(this.cmbMon);
            this.Controls.Add(this.cmbLoai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Order";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.pnlMenuHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.ComboBox cmbMon;
        private System.Windows.Forms.NumericUpDown numericUpDownSoLuong;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.ComboBox cmbChonBanDoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntoMoney;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel pnlMenuHeader;
        private Guna.UI2.WinForms.Guna2TextBox txbSearch;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}