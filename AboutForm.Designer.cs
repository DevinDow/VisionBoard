namespace DevinDow.VisionBoard
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblVisionBoard = new System.Windows.Forms.Label();
            this.lblWrittenBy = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 23);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblVisionBoard
            // 
            this.lblVisionBoard.AutoSize = true;
            this.lblVisionBoard.Location = new System.Drawing.Point(40, 12);
            this.lblVisionBoard.Name = "lblVisionBoard";
            this.lblVisionBoard.Size = new System.Drawing.Size(63, 13);
            this.lblVisionBoard.TabIndex = 1;
            this.lblVisionBoard.Text = "VisionBoard";
            // 
            // lblWrittenBy
            // 
            this.lblWrittenBy.AutoSize = true;
            this.lblWrittenBy.Location = new System.Drawing.Point(40, 25);
            this.lblWrittenBy.Name = "lblWrittenBy";
            this.lblWrittenBy.Size = new System.Drawing.Size(111, 13);
            this.lblWrittenBy.TabIndex = 2;
            this.lblWrittenBy.Text = "Written by Devin Dow";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(40, 38);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(51, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version : ";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(221, 53);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 88);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblWrittenBy);
            this.Controls.Add(this.lblVisionBoard);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About VisionBoard";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVisionBoard;
        private System.Windows.Forms.Label lblWrittenBy;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnOK;
    }
}