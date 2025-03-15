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
            this.btnThemMon = new System.Windows.Forms.Button();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.ColFoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntoMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbChonBanDoi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnDoiBan = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLoai
            // 
            this.cmbLoai.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoai.Location = new System.Drawing.Point(920, 242);
            this.cmbLoai.Margin = new System.Windows.Forms.Padding(5);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(521, 57);
            this.cmbLoai.TabIndex = 0;
            // 
            // cmbMon
            // 
            this.cmbMon.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMon.Location = new System.Drawing.Point(920, 347);
            this.cmbMon.Margin = new System.Windows.Forms.Padding(5);
            this.cmbMon.Name = "cmbMon";
            this.cmbMon.Size = new System.Drawing.Size(521, 57);
            this.cmbMon.TabIndex = 1;
            // 
            // numericUpDownSoLuong
            // 
            this.numericUpDownSoLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(104)))), ((int)(((byte)(96)))));
            this.numericUpDownSoLuong.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSoLuong.ForeColor = System.Drawing.Color.White;
            this.numericUpDownSoLuong.Location = new System.Drawing.Point(1488, 242);
            this.numericUpDownSoLuong.Margin = new System.Windows.Forms.Padding(5);
            this.numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            this.numericUpDownSoLuong.Size = new System.Drawing.Size(282, 57);
            this.numericUpDownSoLuong.TabIndex = 3;
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(202)))));
            this.btnThemMon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.btnThemMon.Location = new System.Drawing.Point(1488, 342);
            this.btnThemMon.Margin = new System.Windows.Forms.Padding(5);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(282, 62);
            this.btnThemMon.TabIndex = 4;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
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
            this.dgvOrder.Location = new System.Drawing.Point(920, 456);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(5);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.Size = new System.Drawing.Size(886, 496);
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
            this.cmbChonBanDoi.Location = new System.Drawing.Point(920, 1102);
            this.cmbChonBanDoi.Margin = new System.Windows.Forms.Padding(5);
            this.cmbChonBanDoi.Name = "cmbChonBanDoi";
            this.cmbChonBanDoi.Size = new System.Drawing.Size(305, 63);
            this.cmbChonBanDoi.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.label1.Location = new System.Drawing.Point(896, 990);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 61);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Amount:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(1274, 990);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(5);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(442, 55);
            this.txtTongTien.TabIndex = 8;
            // 
            // btnDoiBan
            // 
            this.btnDoiBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(104)))), ((int)(((byte)(96)))));
            this.btnDoiBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiBan.ForeColor = System.Drawing.Color.White;
            this.btnDoiBan.Location = new System.Drawing.Point(1219, 1094);
            this.btnDoiBan.Margin = new System.Windows.Forms.Padding(5);
            this.btnDoiBan.Name = "btnDoiBan";
            this.btnDoiBan.Size = new System.Drawing.Size(250, 86);
            this.btnDoiBan.TabIndex = 9;
            this.btnDoiBan.Text = "Switch Tables";
            this.btnDoiBan.UseVisualStyleBackColor = false;
            this.btnDoiBan.Click += new System.EventHandler(this.btnDoiBan_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(104)))), ((int)(((byte)(96)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(1525, 1094);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(5);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(245, 86);
            this.btnThanhToan.TabIndex = 10;
            this.btnThanhToan.Text = "Pay";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.label2.Location = new System.Drawing.Point(1160, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 69);
            this.label2.TabIndex = 12;
            this.label2.Text = "Order";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(920, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(2, 3);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(910, 1229);
            this.flpTable.TabIndex = 13;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1826, 1232);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnDoiBan);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbChonBanDoi);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.btnThemMon);
            this.Controls.Add(this.numericUpDownSoLuong);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.ComboBox cmbMon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownSoLuong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.ComboBox cmbChonBanDoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnDoiBan;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntoMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
    }
}