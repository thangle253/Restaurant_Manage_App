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
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenu = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddFood = new Guna.UI2.WinForms.Guna2Button();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.lblHeaderTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvOderBill = new System.Windows.Forms.DataGridView();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Header = new System.Windows.Forms.Label();
            this.dateOrderBill = new System.Windows.Forms.DateTimePicker();
            this.lblTableName = new System.Windows.Forms.Label();
            this.cbbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbFoodName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.nbrudNumber = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnOrder = new Guna.UI2.WinForms.Guna2Button();
            this.lblHeaderTable = new System.Windows.Forms.Label();
            this.pnlMenuHeader = new System.Windows.Forms.Panel();
            this.txbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTable = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOderBill)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrudNumber)).BeginInit();
            this.pnlMenuHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(2, 66);
            this.flpTable.Margin = new System.Windows.Forms.Padding(0);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(1133, 1163);
            this.flpTable.TabIndex = 13;
            // 
            // btnMenu
            // 
            this.btnMenu.BorderRadius = 10;
            this.btnMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenu.FillColor = System.Drawing.Color.Crimson;
            this.btnMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(923, 3);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(186, 58);
            this.btnMenu.TabIndex = 14;
            this.btnMenu.Text = "Menu";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.BorderRadius = 10;
            this.btnAddFood.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddFood.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddFood.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddFood.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddFood.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddFood.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.ForeColor = System.Drawing.Color.White;
            this.btnAddFood.Location = new System.Drawing.Point(1598, 66);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(210, 58);
            this.btnAddFood.TabIndex = 15;
            this.btnAddFood.Text = "Add Food";
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnPay
            // 
            this.btnPay.BorderRadius = 10;
            this.btnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPay.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(1693, 1139);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(210, 58);
            this.btnPay.TabIndex = 19;
            this.btnPay.Text = "Pay";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnClear
            // 
            this.btnClear.BorderRadius = 10;
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.DeepPink;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1178, 1139);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(210, 58);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear All";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblHeaderTotalAmount
            // 
            this.lblHeaderTotalAmount.AutoSize = true;
            this.lblHeaderTotalAmount.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblHeaderTotalAmount.Location = new System.Drawing.Point(1165, 1058);
            this.lblHeaderTotalAmount.Name = "lblHeaderTotalAmount";
            this.lblHeaderTotalAmount.Size = new System.Drawing.Size(289, 49);
            this.lblHeaderTotalAmount.TabIndex = 25;
            this.lblHeaderTotalAmount.Text = "Total Amount:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(1640, 1058);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(115, 49);
            this.lblTotalAmount.TabIndex = 26;
            this.lblTotalAmount.Text = "VND";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvOderBill);
            this.panel1.Controls.Add(this.guna2Panel1);
            this.panel1.Location = new System.Drawing.Point(1154, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 898);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgvOderBill
            // 
            this.dgvOderBill.BackgroundColor = System.Drawing.Color.White;
            this.dgvOderBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOderBill.Location = new System.Drawing.Point(0, 128);
            this.dgvOderBill.Name = "dgvOderBill";
            this.dgvOderBill.RowHeadersVisible = false;
            this.dgvOderBill.RowHeadersWidth = 82;
            this.dgvOderBill.RowTemplate.Height = 33;
            this.dgvOderBill.Size = new System.Drawing.Size(768, 770);
            this.dgvOderBill.TabIndex = 27;
            this.dgvOderBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOderBill_CellContentClick);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Orange;
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.Header);
            this.guna2Panel1.Controls.Add(this.dateOrderBill);
            this.guna2Panel1.Controls.Add(this.lblTableName);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(768, 125);
            this.guna2Panel1.TabIndex = 21;
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Times New Roman", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Header.Location = new System.Drawing.Point(10, 8);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(238, 61);
            this.Header.TabIndex = 26;
            this.Header.Text = "Oder Bill";
            // 
            // dateOrderBill
            // 
            this.dateOrderBill.CalendarFont = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOrderBill.CalendarForeColor = System.Drawing.Color.Transparent;
            this.dateOrderBill.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dateOrderBill.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dateOrderBill.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dateOrderBill.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dateOrderBill.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOrderBill.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateOrderBill.Location = new System.Drawing.Point(34, 72);
            this.dateOrderBill.Name = "dateOrderBill";
            this.dateOrderBill.Size = new System.Drawing.Size(183, 39);
            this.dateOrderBill.TabIndex = 25;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Times New Roman", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTableName.Location = new System.Drawing.Point(518, 32);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(118, 61);
            this.lblTableName.TabIndex = 24;
            this.lblTableName.Text = "Bàn";
            // 
            // cbbCategory
            // 
            this.cbbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cbbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbCategory.ItemHeight = 30;
            this.cbbCategory.Location = new System.Drawing.Point(1178, 6);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(343, 36);
            this.cbbCategory.TabIndex = 27;
            this.cbbCategory.SelectedIndexChanged += new System.EventHandler(this.cbbCategory_SelectedIndexChanged);
            // 
            // cbbFoodName
            // 
            this.cbbFoodName.BackColor = System.Drawing.Color.Transparent;
            this.cbbFoodName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbFoodName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFoodName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbFoodName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbFoodName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFoodName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbFoodName.ItemHeight = 30;
            this.cbbFoodName.Location = new System.Drawing.Point(1178, 66);
            this.cbbFoodName.Name = "cbbFoodName";
            this.cbbFoodName.Size = new System.Drawing.Size(343, 36);
            this.cbbFoodName.TabIndex = 28;
            // 
            // nbrudNumber
            // 
            this.nbrudNumber.BackColor = System.Drawing.Color.Transparent;
            this.nbrudNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbrudNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nbrudNumber.Location = new System.Drawing.Point(1598, 3);
            this.nbrudNumber.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nbrudNumber.Name = "nbrudNumber";
            this.nbrudNumber.Size = new System.Drawing.Size(110, 51);
            this.nbrudNumber.TabIndex = 29;
            // 
            // btnOrder
            // 
            this.btnOrder.BorderRadius = 10;
            this.btnOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOrder.FillColor = System.Drawing.Color.Green;
            this.btnOrder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(1430, 1139);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(210, 58);
            this.btnOrder.TabIndex = 30;
            this.btnOrder.Text = "Order";
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lblHeaderTable
            // 
            this.lblHeaderTable.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTable.ForeColor = System.Drawing.Color.Crimson;
            this.lblHeaderTable.Location = new System.Drawing.Point(148, 9);
            this.lblHeaderTable.Name = "lblHeaderTable";
            this.lblHeaderTable.Size = new System.Drawing.Size(691, 49);
            this.lblHeaderTable.TabIndex = 26;
            this.lblHeaderTable.Text = "Please select a table before ordering \n\n\n\n\n\n\n\n";
            // 
            // pnlMenuHeader
            // 
            this.pnlMenuHeader.Controls.Add(this.txbSearch);
            this.pnlMenuHeader.Controls.Add(this.btnTable);
            this.pnlMenuHeader.Location = new System.Drawing.Point(5, 3);
            this.pnlMenuHeader.Name = "pnlMenuHeader";
            this.pnlMenuHeader.Size = new System.Drawing.Size(912, 64);
            this.pnlMenuHeader.TabIndex = 27;
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
            this.txbSearch.Location = new System.Drawing.Point(290, 3);
            this.txbSearch.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txbSearch.PlaceholderText = "                 Search in here";
            this.txbSearch.SelectedText = "";
            this.txbSearch.Size = new System.Drawing.Size(544, 56);
            this.txbSearch.TabIndex = 16;
            this.txbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSearch_KeyDown);
            // 
            // btnTable
            // 
            this.btnTable.BorderRadius = 10;
            this.btnTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTable.FillColor = System.Drawing.Color.DarkOrange;
            this.btnTable.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.ForeColor = System.Drawing.Color.White;
            this.btnTable.Location = new System.Drawing.Point(19, 2);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(195, 58);
            this.btnTable.TabIndex = 15;
            this.btnTable.Text = "Table";
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1933, 1280);
            this.Controls.Add(this.pnlMenuHeader);
            this.Controls.Add(this.lblHeaderTable);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.nbrudNumber);
            this.Controls.Add(this.cbbFoodName);
            this.Controls.Add(this.cbbCategory);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeaderTotalAmount);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.flpTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Order";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOderBill)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrudNumber)).EndInit();
            this.pnlMenuHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private Guna.UI2.WinForms.Guna2Button btnMenu;
        private Guna.UI2.WinForms.Guna2Button btnAddFood;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private System.Windows.Forms.Label lblHeaderTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.DateTimePicker dateOrderBill;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.DataGridView dgvOderBill;
        private Guna.UI2.WinForms.Guna2ComboBox cbbCategory;
        private Guna.UI2.WinForms.Guna2ComboBox cbbFoodName;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbrudNumber;
        private Guna.UI2.WinForms.Guna2Button btnOrder;
        private System.Windows.Forms.Label lblHeaderTable;
        private System.Windows.Forms.Panel pnlMenuHeader;
        private Guna.UI2.WinForms.Guna2TextBox txbSearch;
        private Guna.UI2.WinForms.Guna2Button btnTable;
    }
}