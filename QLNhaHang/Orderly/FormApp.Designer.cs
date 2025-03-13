namespace Orderly
{
    partial class FormApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApp));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnRevenus = new System.Windows.Forms.Button();
            this.btnCategogy = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblQuayLai = new System.Windows.Forms.Label();
            this.lblThoat = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnlGiaoDienChin = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnlGiaoDienChin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.SandyBrown;
            this.pnlSide.Controls.Add(this.btnAccount);
            this.pnlSide.Controls.Add(this.btnRevenus);
            this.pnlSide.Controls.Add(this.btnCategogy);
            this.pnlSide.Controls.Add(this.btnHome);
            this.pnlSide.Controls.Add(this.btnTable);
            this.pnlSide.Controls.Add(this.btnFood);
            this.pnlSide.Controls.Add(this.btnOrder);
            this.pnlSide.Controls.Add(this.pictureBox1);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(233, 672);
            this.pnlSide.TabIndex = 0;
            // 
            // btnAccount
            // 
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnAccount.Image")));
            this.btnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.Location = new System.Drawing.Point(3, 609);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(230, 60);
            this.btnAccount.TabIndex = 10;
            this.btnAccount.Text = "     Account";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnRevenus
            // 
            this.btnRevenus.BackColor = System.Drawing.Color.Transparent;
            this.btnRevenus.FlatAppearance.BorderSize = 0;
            this.btnRevenus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevenus.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenus.Image = ((System.Drawing.Image)(resources.GetObject("btnRevenus.Image")));
            this.btnRevenus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRevenus.Location = new System.Drawing.Point(3, 547);
            this.btnRevenus.Name = "btnRevenus";
            this.btnRevenus.Size = new System.Drawing.Size(230, 56);
            this.btnRevenus.TabIndex = 9;
            this.btnRevenus.Text = "    Revenus";
            this.btnRevenus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRevenus.UseVisualStyleBackColor = false;
            this.btnRevenus.Click += new System.EventHandler(this.btnRevenus_Click);
            // 
            // btnCategogy
            // 
            this.btnCategogy.BackColor = System.Drawing.Color.Transparent;
            this.btnCategogy.FlatAppearance.BorderSize = 0;
            this.btnCategogy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategogy.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategogy.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCategogy.Image = ((System.Drawing.Image)(resources.GetObject("btnCategogy.Image")));
            this.btnCategogy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategogy.Location = new System.Drawing.Point(3, 486);
            this.btnCategogy.Name = "btnCategogy";
            this.btnCategogy.Size = new System.Drawing.Size(230, 55);
            this.btnCategogy.TabIndex = 8;
            this.btnCategogy.Text = "     Categogy";
            this.btnCategogy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategogy.UseVisualStyleBackColor = false;
            this.btnCategogy.Click += new System.EventHandler(this.btnCategogy_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 240);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(230, 55);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "   Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.Transparent;
            this.btnTable.FlatAppearance.BorderSize = 0;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.Image = ((System.Drawing.Image)(resources.GetObject("btnTable.Image")));
            this.btnTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTable.Location = new System.Drawing.Point(3, 428);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(230, 55);
            this.btnTable.TabIndex = 5;
            this.btnTable.Text = "  Table";
            this.btnTable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnFood
            // 
            this.btnFood.BackColor = System.Drawing.Color.Transparent;
            this.btnFood.FlatAppearance.BorderSize = 0;
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFood.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFood.Image = ((System.Drawing.Image)(resources.GetObject("btnFood.Image")));
            this.btnFood.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFood.Location = new System.Drawing.Point(0, 367);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(230, 55);
            this.btnFood.TabIndex = 4;
            this.btnFood.Text = "  Food";
            this.btnFood.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFood.UseVisualStyleBackColor = false;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Times New Roman", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(0, 306);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(230, 55);
            this.btnOrder.TabIndex = 3;
            this.btnOrder.Text = "  Order";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 234);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(26)))), ((int)(((byte)(8)))));
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.lblQuayLai);
            this.pnlHeader.Controls.Add(this.lblThoat);
            this.pnlHeader.Controls.Add(this.pictureBox4);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(233, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(926, 57);
            this.pnlHeader.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(91, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(574, 45);
            this.label4.TabIndex = 7;
            this.label4.Text = "Restaurant Management System";
            // 
            // lblQuayLai
            // 
            this.lblQuayLai.AutoSize = true;
            this.lblQuayLai.BackColor = System.Drawing.Color.MediumTurquoise;
            this.lblQuayLai.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuayLai.ForeColor = System.Drawing.Color.White;
            this.lblQuayLai.Location = new System.Drawing.Point(849, 11);
            this.lblQuayLai.Name = "lblQuayLai";
            this.lblQuayLai.Size = new System.Drawing.Size(36, 41);
            this.lblQuayLai.TabIndex = 6;
            this.lblQuayLai.Text = "–";
            this.lblQuayLai.Click += new System.EventHandler(this.lblQuayLai_Click);
            // 
            // lblThoat
            // 
            this.lblThoat.AutoSize = true;
            this.lblThoat.BackColor = System.Drawing.Color.Red;
            this.lblThoat.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoat.ForeColor = System.Drawing.Color.White;
            this.lblThoat.Location = new System.Drawing.Point(885, 12);
            this.lblThoat.Name = "lblThoat";
            this.lblThoat.Size = new System.Drawing.Size(36, 41);
            this.lblThoat.TabIndex = 5;
            this.lblThoat.Text = "x";
            this.lblThoat.Click += new System.EventHandler(this.lblThoat_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(21, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 51);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pnlGiaoDienChin
            // 
            this.pnlGiaoDienChin.BackColor = System.Drawing.Color.Cornsilk;
            this.pnlGiaoDienChin.Controls.Add(this.pictureBox2);
            this.pnlGiaoDienChin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGiaoDienChin.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGiaoDienChin.Location = new System.Drawing.Point(233, 57);
            this.pnlGiaoDienChin.Name = "pnlGiaoDienChin";
            this.pnlGiaoDienChin.Size = new System.Drawing.Size(926, 615);
            this.pnlGiaoDienChin.TabIndex = 7;
            this.pnlGiaoDienChin.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGiaoDienChin_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(926, 617);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // FormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(27F, 67F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1159, 672);
            this.Controls.Add(this.pnlGiaoDienChin);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSide);
            this.Font = new System.Drawing.Font("Segoe Script", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.Name = "FormApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormApp";
            this.pnlSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnlGiaoDienChin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblThoat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblQuayLai;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCategogy;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnRevenus;
        private System.Windows.Forms.Panel pnlGiaoDienChin;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}