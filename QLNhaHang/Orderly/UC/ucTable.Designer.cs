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
            this.picTable = new System.Windows.Forms.PictureBox();
            this.lblTableName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).BeginInit();
            this.SuspendLayout();
            // 
            // picTable
            // 
            this.picTable.BackColor = System.Drawing.Color.Transparent;
            this.picTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picTable.BackgroundImage")));
            this.picTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTable.InitialImage = null;
            this.picTable.Location = new System.Drawing.Point(38, 23);
            this.picTable.Name = "picTable";
            this.picTable.Size = new System.Drawing.Size(132, 97);
            this.picTable.TabIndex = 1;
            this.picTable.TabStop = false;
            this.picTable.Click += new System.EventHandler(this.picTable_Click);
            // 
            // lblTableName
            // 
            this.lblTableName.BackColor = System.Drawing.Color.Transparent;
            this.lblTableName.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTableName.Location = new System.Drawing.Point(31, 0);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(139, 39);
            this.lblTableName.TabIndex = 5;
            this.lblTableName.Text = "Bàn";
            this.lblTableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.picTable);
            this.Name = "ucTable";
            this.Size = new System.Drawing.Size(205, 131);
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picTable;
        private System.Windows.Forms.Label lblTableName;
    }
}
