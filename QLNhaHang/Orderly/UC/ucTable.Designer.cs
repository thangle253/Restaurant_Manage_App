namespace Orderly.UC
{
    partial class ucTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTable));
            this.panelTable = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTableName = new System.Windows.Forms.Label();
            this.picTable = new System.Windows.Forms.PictureBox();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTable
            // 
            this.panelTable.Controls.Add(this.lblTableName);
            this.panelTable.Controls.Add(this.picTable);
            this.panelTable.Location = new System.Drawing.Point(3, 3);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(183, 158);
            this.panelTable.TabIndex = 10;
            // 
            // lblTableName
            // 
            this.lblTableName.BackColor = System.Drawing.Color.Transparent;
            this.lblTableName.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.ForeColor = System.Drawing.Color.Black;
            this.lblTableName.Location = new System.Drawing.Point(3, 11);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(176, 42);
            this.lblTableName.TabIndex = 12;
            this.lblTableName.Text = "Bàn";
            this.lblTableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picTable
            // 
            this.picTable.BackColor = System.Drawing.Color.Transparent;
            this.picTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picTable.BackgroundImage")));
            this.picTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTable.InitialImage = null;
            this.picTable.Location = new System.Drawing.Point(14, 37);
            this.picTable.Margin = new System.Windows.Forms.Padding(1);
            this.picTable.Name = "picTable";
            this.picTable.Size = new System.Drawing.Size(150, 100);
            this.picTable.TabIndex = 11;
            this.picTable.TabStop = false;
            this.picTable.Click += new System.EventHandler(this.picTable_Click_2);
            // 
            // ucTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelTable);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucTable";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(193, 166);
            this.Load += new System.EventHandler(this.ucTable_Load);
            this.panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelTable;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.PictureBox picTable;
    }
}
