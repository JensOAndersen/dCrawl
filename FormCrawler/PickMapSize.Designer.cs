namespace FormCrawler
{
    partial class PickMapSize
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
            this.PickSizeLabel = new System.Windows.Forms.Label();
            this.MapColumns = new System.Windows.Forms.ComboBox();
            this.MapRows = new System.Windows.Forms.ComboBox();
            this.SizeLabelCol = new System.Windows.Forms.Label();
            this.SizeLabelRow = new System.Windows.Forms.Label();
            this.SizeSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PickSizeLabel
            // 
            this.PickSizeLabel.AutoSize = true;
            this.PickSizeLabel.Location = new System.Drawing.Point(69, 21);
            this.PickSizeLabel.Name = "PickSizeLabel";
            this.PickSizeLabel.Size = new System.Drawing.Size(161, 17);
            this.PickSizeLabel.TabIndex = 0;
            this.PickSizeLabel.Text = "Please choose map size";
            this.PickSizeLabel.Click += new System.EventHandler(this.PickSizeLabel_Click);
            // 
            // MapColumns
            // 
            this.MapColumns.FormattingEnabled = true;
            this.MapColumns.Location = new System.Drawing.Point(33, 78);
            this.MapColumns.Name = "MapColumns";
            this.MapColumns.Size = new System.Drawing.Size(90, 24);
            this.MapColumns.TabIndex = 1;
            this.MapColumns.SelectedIndexChanged += new System.EventHandler(this.MapColumns_SelectedIndexChanged);
            // 
            // MapRows
            // 
            this.MapRows.FormattingEnabled = true;
            this.MapRows.Location = new System.Drawing.Point(172, 78);
            this.MapRows.Name = "MapRows";
            this.MapRows.Size = new System.Drawing.Size(90, 24);
            this.MapRows.TabIndex = 2;
            this.MapRows.SelectedIndexChanged += new System.EventHandler(this.MapRows_SelectedIndexChanged);
            // 
            // SizeLabelCol
            // 
            this.SizeLabelCol.AutoSize = true;
            this.SizeLabelCol.Location = new System.Drawing.Point(30, 58);
            this.SizeLabelCol.Name = "SizeLabelCol";
            this.SizeLabelCol.Size = new System.Drawing.Size(54, 17);
            this.SizeLabelCol.TabIndex = 3;
            this.SizeLabelCol.Text = "Colums";
            // 
            // SizeLabelRow
            // 
            this.SizeLabelRow.AutoSize = true;
            this.SizeLabelRow.Location = new System.Drawing.Point(169, 58);
            this.SizeLabelRow.Name = "SizeLabelRow";
            this.SizeLabelRow.Size = new System.Drawing.Size(42, 17);
            this.SizeLabelRow.TabIndex = 4;
            this.SizeLabelRow.Text = "Rows";
            // 
            // SizeSubmit
            // 
            this.SizeSubmit.Location = new System.Drawing.Point(84, 142);
            this.SizeSubmit.Name = "SizeSubmit";
            this.SizeSubmit.Size = new System.Drawing.Size(127, 23);
            this.SizeSubmit.TabIndex = 5;
            this.SizeSubmit.Text = "Generate Map!";
            this.SizeSubmit.UseVisualStyleBackColor = true;
            this.SizeSubmit.Click += new System.EventHandler(this.SizeSubmit_Click);
            // 
            // PickMapSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 213);
            this.Controls.Add(this.SizeSubmit);
            this.Controls.Add(this.SizeLabelRow);
            this.Controls.Add(this.SizeLabelCol);
            this.Controls.Add(this.MapRows);
            this.Controls.Add(this.MapColumns);
            this.Controls.Add(this.PickSizeLabel);
            this.Name = "PickMapSize";
            this.Text = "PickMapSize";
            this.Load += new System.EventHandler(this.PickMapSize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PickSizeLabel;
        private System.Windows.Forms.ComboBox MapColumns;
        private System.Windows.Forms.ComboBox MapRows;
        private System.Windows.Forms.Label SizeLabelCol;
        private System.Windows.Forms.Label SizeLabelRow;
        private System.Windows.Forms.Button SizeSubmit;
    }
}