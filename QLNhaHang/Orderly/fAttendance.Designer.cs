namespace Orderly
{
    partial class fAttendance
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
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnViewInfo = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblBaseSalary = new System.Windows.Forms.Label();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.pnlInfor = new System.Windows.Forms.Panel();
            this.txtBaseSalary = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.pnlInfor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.LightGreen;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.Location = new System.Drawing.Point(5, 0);
            this.btnCheckIn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(239, 119);
            this.btnCheckIn.TabIndex = 0;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnViewInfo
            // 
            this.btnViewInfo.BackColor = System.Drawing.Color.SkyBlue;
            this.btnViewInfo.FlatAppearance.BorderSize = 0;
            this.btnViewInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInfo.Location = new System.Drawing.Point(805, 0);
            this.btnViewInfo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnViewInfo.Name = "btnViewInfo";
            this.btnViewInfo.Size = new System.Drawing.Size(239, 119);
            this.btnViewInfo.TabIndex = 1;
            this.btnViewInfo.Text = "View";
            this.btnViewInfo.UseVisualStyleBackColor = false;
            this.btnViewInfo.Click += new System.EventHandler(this.btnViewInfo_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Crimson;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.Location = new System.Drawing.Point(409, 0);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(239, 119);
            this.btnCheckOut.TabIndex = 2;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(35, 19);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(200, 46);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(35, 97);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(269, 46);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(35, 187);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(162, 46);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address:";
            // 
            // lblBaseSalary
            // 
            this.lblBaseSalary.AutoSize = true;
            this.lblBaseSalary.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseSalary.Location = new System.Drawing.Point(35, 276);
            this.lblBaseSalary.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBaseSalary.Name = "lblBaseSalary";
            this.lblBaseSalary.Size = new System.Drawing.Size(229, 46);
            this.lblBaseSalary.TabIndex = 6;
            this.lblBaseSalary.Text = "Basic Salary:";
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.EnableHeadersVisualStyles = false;
            this.dgvAttendance.Location = new System.Drawing.Point(231, 685);
            this.dgvAttendance.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            this.dgvAttendance.RowHeadersVisible = false;
            this.dgvAttendance.RowHeadersWidth = 62;
            this.dgvAttendance.RowTemplate.Height = 28;
            this.dgvAttendance.Size = new System.Drawing.Size(1049, 393);
            this.dgvAttendance.TabIndex = 7;
            // 
            // pnlInfor
            // 
            this.pnlInfor.Controls.Add(this.txtBaseSalary);
            this.pnlInfor.Controls.Add(this.txtAddress);
            this.pnlInfor.Controls.Add(this.txtPhone);
            this.pnlInfor.Controls.Add(this.txtFullName);
            this.pnlInfor.Controls.Add(this.lblFullName);
            this.pnlInfor.Controls.Add(this.lblPhone);
            this.pnlInfor.Controls.Add(this.lblBaseSalary);
            this.pnlInfor.Controls.Add(this.lblAddress);
            this.pnlInfor.Location = new System.Drawing.Point(231, 257);
            this.pnlInfor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlInfor.Name = "pnlInfor";
            this.pnlInfor.Size = new System.Drawing.Size(1049, 393);
            this.pnlInfor.TabIndex = 8;
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseSalary.Location = new System.Drawing.Point(332, 275);
            this.txtBaseSalary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(685, 44);
            this.txtBaseSalary.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(332, 185);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(685, 44);
            this.txtAddress.TabIndex = 9;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(332, 101);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(685, 44);
            this.txtPhone.TabIndex = 8;
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(332, 23);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(685, 44);
            this.txtFullName.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCheckIn);
            this.panel1.Controls.Add(this.btnCheckOut);
            this.panel1.Controls.Add(this.btnViewInfo);
            this.panel1.Location = new System.Drawing.Point(231, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 125);
            this.panel1.TabIndex = 9;
            // 
            // fAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(1537, 1127);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlInfor);
            this.Controls.Add(this.dgvAttendance);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "fAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check In/Out";
            this.Load += new System.EventHandler(this.fAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.pnlInfor.ResumeLayout(false);
            this.pnlInfor.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnViewInfo;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblBaseSalary;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Panel pnlInfor;
        private System.Windows.Forms.TextBox txtBaseSalary;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Panel panel1;
    }
}