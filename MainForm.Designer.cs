namespace DevinDow.VisionBoard
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.miFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveVisionBoardImage = new System.Windows.Forms.ToolStripMenuItem();
            this.miWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.miScreensaver = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPaste});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(113, 26);
            // 
            // miPaste
            // 
            this.miPaste.Name = "miPaste";
            this.miPaste.Size = new System.Drawing.Size(112, 22);
            this.miPaste.Text = "&Paste";
            this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.miView,
            this.miPrint,
            this.miSaveVisionBoardImage,
            this.miWallpaper,
            this.miScreensaver,
            this.miHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(804, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miLoad,
            this.miSave,
            this.miSaveAs,
            this.toolStripMenuItem1,
            this.miExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(124, 22);
            this.miNew.Text = "&New";
            this.miNew.Click += new System.EventHandler(this.miNew_Click);
            // 
            // miLoad
            // 
            this.miLoad.Name = "miLoad";
            this.miLoad.Size = new System.Drawing.Size(124, 22);
            this.miLoad.Text = "&Load";
            this.miLoad.Click += new System.EventHandler(this.miLoad_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(124, 22);
            this.miSave.Text = "&Save";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.Size = new System.Drawing.Size(124, 22);
            this.miSaveAs.Text = "Save &As";
            this.miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(124, 22);
            this.miExit.Text = "E&xit";
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPlay,
            this.miFullScreen});
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(41, 20);
            this.miView.Text = "&View";
            // 
            // miPlay
            // 
            this.miPlay.Name = "miPlay";
            this.miPlay.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miPlay.Size = new System.Drawing.Size(162, 22);
            this.miPlay.Text = "&Play";
            this.miPlay.Click += new System.EventHandler(this.miPlay_Click);
            // 
            // miFullScreen
            // 
            this.miFullScreen.Name = "miFullScreen";
            this.miFullScreen.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.miFullScreen.Size = new System.Drawing.Size(162, 22);
            this.miFullScreen.Text = "&Full Screen";
            this.miFullScreen.Click += new System.EventHandler(this.miFullScreen_Click);
            // 
            // miPrint
            // 
            this.miPrint.Name = "miPrint";
            this.miPrint.Size = new System.Drawing.Size(41, 20);
            this.miPrint.Text = "&Print";
            this.miPrint.Click += new System.EventHandler(this.miPrint_Click);
            // 
            // miSaveVisionBoardImage
            // 
            this.miSaveVisionBoardImage.Name = "miSaveVisionBoardImage";
            this.miSaveVisionBoardImage.Size = new System.Drawing.Size(134, 20);
            this.miSaveVisionBoardImage.Text = "Save &VisionBoard &Image";
            this.miSaveVisionBoardImage.Click += new System.EventHandler(this.miSaveVisionBoardImage_Click);
            // 
            // miWallpaper
            // 
            this.miWallpaper.Name = "miWallpaper";
            this.miWallpaper.Size = new System.Drawing.Size(100, 20);
            this.miWallpaper.Text = "Set as &Wallpaper";
            this.miWallpaper.Click += new System.EventHandler(this.miWallpaper_Click);
            // 
            // miScreensaver
            // 
            this.miScreensaver.Name = "miScreensaver";
            this.miScreensaver.Size = new System.Drawing.Size(112, 20);
            this.miScreensaver.Text = "Set as &Screensaver";
            this.miScreensaver.Click += new System.EventHandler(this.miScreensaver_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInstructions,
            this.miAbout,
            this.miUpdates});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(40, 20);
            this.miHelp.Text = "&Help";
            // 
            // miInstructions
            // 
            this.miInstructions.Name = "miInstructions";
            this.miInstructions.Size = new System.Drawing.Size(174, 22);
            this.miInstructions.Text = "&Instructions";
            this.miInstructions.Click += new System.EventHandler(this.miInstructions_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(174, 22);
            this.miAbout.Text = "&About VisionBoard";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miUpdates
            // 
            this.miUpdates.Enabled = false;
            this.miUpdates.Name = "miUpdates";
            this.miUpdates.Size = new System.Drawing.Size(174, 22);
            this.miUpdates.Text = "Check for &Updates";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(804, 392);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Vision Board";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem miPaste;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miLoad;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miWallpaper;
        private System.Windows.Forms.ToolStripMenuItem miScreensaver;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miPlay;
        private System.Windows.Forms.ToolStripMenuItem miFullScreen;
        private System.Windows.Forms.ToolStripMenuItem miPrint;
        private System.Windows.Forms.ToolStripMenuItem miInstructions;
        private System.Windows.Forms.ToolStripMenuItem miUpdates;
        private System.Windows.Forms.ToolStripMenuItem miSaveVisionBoardImage;
    }
}

