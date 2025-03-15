namespace Orderly
{
    partial class fCheckInOut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnStart = new Guna.UI2.WinForms.Guna2Button();
            this.btnEnd = new Guna.UI2.WinForms.Guna2Button();
            this.grpShiftSelection = new System.Windows.Forms.GroupBox();
            this.rdoAfternoonShift = new System.Windows.Forms.RadioButton();
            this.rdoEveningShift = new System.Windows.Forms.RadioButton();
            this.rdoMorningShift = new System.Windows.Forms.RadioButton();
            this.dgvAttendanceHistory = new System.Windows.Forms.DataGridView();
            this.lblTitleTime = new System.Windows.Forms.Label();
            this.lblWorkingTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.grpShiftSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Black;
            this.btnStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStart.FillColor = System.Drawing.Color.ForestGreen;
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(24, 281);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(207, 83);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Work";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEnd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEnd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEnd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEnd.FillColor = System.Drawing.Color.Brown;
            this.btnEnd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.ForeColor = System.Drawing.Color.White;
            this.btnEnd.Location = new System.Drawing.Point(393, 281);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(200, 83);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "End Work";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // grpShiftSelection
            // 
            this.grpShiftSelection.Controls.Add(this.rdoAfternoonShift);
            this.grpShiftSelection.Controls.Add(this.rdoEveningShift);
            this.grpShiftSelection.Controls.Add(this.rdoMorningShift);
            this.grpShiftSelection.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpShiftSelection.ForeColor = System.Drawing.Color.MediumBlue;
            this.grpShiftSelection.Location = new System.Drawing.Point(24, 12);
            this.grpShiftSelection.Name = "grpShiftSelection";
            this.grpShiftSelection.Size = new System.Drawing.Size(569, 243);
            this.grpShiftSelection.TabIndex = 2;
            this.grpShiftSelection.TabStop = false;
            this.grpShiftSelection.Text = "Shift Selection";
            // 
            // rdoAfternoonShift
            // 
            this.rdoAfternoonShift.AutoSize = true;
            this.rdoAfternoonShift.Location = new System.Drawing.Point(6, 100);
            this.rdoAfternoonShift.Name = "rdoAfternoonShift";
            this.rdoAfternoonShift.Size = new System.Drawing.Size(462, 39);
            this.rdoAfternoonShift.TabIndex = 2;
            this.rdoAfternoonShift.TabStop = true;
            this.rdoAfternoonShift.Text = " (Afternoon Shift: 11 AM - 2 PM)";
            this.rdoAfternoonShift.UseVisualStyleBackColor = true;
            // 
            // rdoEveningShift
            // 
            this.rdoEveningShift.AutoSize = true;
            this.rdoEveningShift.Location = new System.Drawing.Point(6, 173);
            this.rdoEveningShift.Name = "rdoEveningShift";
            this.rdoEveningShift.Size = new System.Drawing.Size(430, 39);
            this.rdoEveningShift.TabIndex = 1;
            this.rdoEveningShift.TabStop = true;
            this.rdoEveningShift.Text = "(Evening Shift: 6 PM - 10 PM)";
            this.rdoEveningShift.UseVisualStyleBackColor = true;
            // 
            // rdoMorningShift
            // 
            this.rdoMorningShift.AutoSize = true;
            this.rdoMorningShift.Location = new System.Drawing.Point(6, 34);
            this.rdoMorningShift.Name = "rdoMorningShift";
            this.rdoMorningShift.Size = new System.Drawing.Size(436, 39);
            this.rdoMorningShift.TabIndex = 0;
            this.rdoMorningShift.TabStop = true;
            this.rdoMorningShift.Text = "(Morning Shift: 7 AM - 11 AM)";
            this.rdoMorningShift.UseVisualStyleBackColor = true;
            // 
            // dgvAttendanceHistory
            // 
            this.dgvAttendanceHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendanceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendanceHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttendanceHistory.GridColor = System.Drawing.Color.Black;
            this.dgvAttendanceHistory.Location = new System.Drawing.Point(24, 385);
            this.dgvAttendanceHistory.Name = "dgvAttendanceHistory";
            this.dgvAttendanceHistory.RowHeadersWidth = 62;
            this.dgvAttendanceHistory.RowTemplate.Height = 28;
            this.dgvAttendanceHistory.Size = new System.Drawing.Size(952, 292);
            this.dgvAttendanceHistory.TabIndex = 3;
            this.dgvAttendanceHistory.VirtualMode = true;
            // 
            // lblTitleTime
            // 
            this.lblTitleTime.AutoSize = true;
            this.lblTitleTime.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTime.Location = new System.Drawing.Point(620, 44);
            this.lblTitleTime.Name = "lblTitleTime";
            this.lblTitleTime.Size = new System.Drawing.Size(291, 41);
            this.lblTitleTime.TabIndex = 6;
            this.lblTitleTime.Text = "Start work hours:";
            // 
            // lblWorkingTime
            // 
            this.lblWorkingTime.AutoSize = true;
            this.lblWorkingTime.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkingTime.Location = new System.Drawing.Point(620, 110);
            this.lblWorkingTime.Name = "lblWorkingTime";
            this.lblWorkingTime.Size = new System.Drawing.Size(168, 41);
            this.lblWorkingTime.TabIndex = 4;
            this.lblWorkingTime.Text = "WorkTime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(620, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 41);
            this.label1.TabIndex = 7;
            this.label1.Text = "Hourly Salary:";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.Location = new System.Drawing.Point(620, 247);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(54, 41);
            this.lblSalary.TabIndex = 5;
            this.lblSalary.Text = "0đ";
            // 
            // fCheckInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(1453, 703);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitleTime);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblWorkingTime);
            this.Controls.Add(this.dgvAttendanceHistory);
            this.Controls.Add(this.grpShiftSelection);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fCheckInOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check In Out";
            this.Load += new System.EventHandler(this.fCheckInOut_Load);
            this.grpShiftSelection.ResumeLayout(false);
            this.grpShiftSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnStart;
        private Guna.UI2.WinForms.Guna2Button btnEnd;
        private System.Windows.Forms.GroupBox grpShiftSelection;
        private System.Windows.Forms.RadioButton rdoAfternoonShift;
        private System.Windows.Forms.RadioButton rdoEveningShift;
        private System.Windows.Forms.RadioButton rdoMorningShift;
        private System.Windows.Forms.DataGridView dgvAttendanceHistory;
        private System.Windows.Forms.Label lblTitleTime;
        private System.Windows.Forms.Label lblWorkingTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSalary;
    }
}