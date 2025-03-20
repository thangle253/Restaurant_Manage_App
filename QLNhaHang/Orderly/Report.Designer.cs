namespace Orderly
{
    partial class Report
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
            this.crtrptBill = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crtrptBill
            // 
            this.crtrptBill.ActiveViewIndex = -1;
            this.crtrptBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtrptBill.Cursor = System.Windows.Forms.Cursors.Default;
            this.crtrptBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtrptBill.Location = new System.Drawing.Point(0, 0);
            this.crtrptBill.Name = "crtrptBill";
            this.crtrptBill.Size = new System.Drawing.Size(1355, 1173);
            this.crtrptBill.TabIndex = 0;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 1173);
            this.Controls.Add(this.crtrptBill);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crtrptBill;
    }
}