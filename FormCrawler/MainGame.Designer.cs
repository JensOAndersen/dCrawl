namespace FormCrawler
{
    partial class MainGame
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
            this.BtnUp = new System.Windows.Forms.Button();
            this.BtnDown = new System.Windows.Forms.Button();
            this.BtnLeft = new System.Windows.Forms.Button();
            this.BtnRight = new System.Windows.Forms.Button();
            this.RoomCommunication = new System.Windows.Forms.TextBox();
            this.LookForItems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnUp
            // 
            this.BtnUp.Location = new System.Drawing.Point(184, 26);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(75, 32);
            this.BtnUp.TabIndex = 0;
            this.BtnUp.Text = "Up";
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.Location = new System.Drawing.Point(184, 320);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(75, 32);
            this.BtnDown.TabIndex = 1;
            this.BtnDown.Text = "Down";
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // BtnLeft
            // 
            this.BtnLeft.Location = new System.Drawing.Point(13, 174);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(75, 32);
            this.BtnLeft.TabIndex = 2;
            this.BtnLeft.Text = "Left";
            this.BtnLeft.UseVisualStyleBackColor = true;
            this.BtnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // BtnRight
            // 
            this.BtnRight.Location = new System.Drawing.Point(350, 174);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(75, 32);
            this.BtnRight.TabIndex = 3;
            this.BtnRight.Text = "Right";
            this.BtnRight.UseVisualStyleBackColor = true;
            this.BtnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // RoomCommunication
            // 
            this.RoomCommunication.Location = new System.Drawing.Point(94, 64);
            this.RoomCommunication.Multiline = true;
            this.RoomCommunication.Name = "RoomCommunication";
            this.RoomCommunication.ReadOnly = true;
            this.RoomCommunication.Size = new System.Drawing.Size(250, 250);
            this.RoomCommunication.TabIndex = 4;
            // 
            // LookForItems
            // 
            this.LookForItems.Location = new System.Drawing.Point(13, 362);
            this.LookForItems.Name = "LookForItems";
            this.LookForItems.Size = new System.Drawing.Size(134, 39);
            this.LookForItems.TabIndex = 5;
            this.LookForItems.Text = "Look for items";
            this.LookForItems.UseVisualStyleBackColor = true;
            this.LookForItems.Click += new System.EventHandler(this.LookForItems_Click);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 609);
            this.Controls.Add(this.LookForItems);
            this.Controls.Add(this.RoomCommunication);
            this.Controls.Add(this.BtnRight);
            this.Controls.Add(this.BtnLeft);
            this.Controls.Add(this.BtnDown);
            this.Controls.Add(this.BtnUp);
            this.Name = "MainGame";
            this.Text = "Form Crawler";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainGame_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RoomCommunication;
        private System.Windows.Forms.Button BtnRight;
        private System.Windows.Forms.Button BtnLeft;
        private System.Windows.Forms.Button BtnDown;
        private System.Windows.Forms.Button BtnUp;
        private System.Windows.Forms.Button LookForItems;
    }
}

