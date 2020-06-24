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
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.miFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.miReorder = new System.Windows.Forms.ToolStripMenuItem();
            this.miMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveVisionBoardImage = new System.Windows.Forms.ToolStripMenuItem();
            this.miWallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.miScreensaver = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.miAssocVDB = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextMenuStrip.Size = new System.Drawing.Size(103, 26);
            // 
            // miPaste
            // 
            this.miPaste.Name = "miPaste";
            this.miPaste.Size = new System.Drawing.Size(102, 22);
            this.miPaste.Text = "&Paste";
            this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.miView,
            this.miMedia,
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
            this.miSaveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(114, 22);
            this.miNew.Text = "&New";
            this.miNew.Click += new System.EventHandler(this.miNew_Click);
            // 
            // miLoad
            // 
            this.miLoad.Name = "miLoad";
            this.miLoad.Size = new System.Drawing.Size(114, 22);
            this.miLoad.Text = "&Load";
            this.miLoad.Click += new System.EventHandler(this.miLoad_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(114, 22);
            this.miSave.Text = "&Save";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.Size = new System.Drawing.Size(114, 22);
            this.miSaveAs.Text = "Save &As";
            this.miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPlay,
            this.miFullScreen,
            this.miReorder});
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(44, 20);
            this.miView.Text = "&View";
            // 
            // miPlay
            // 
            this.miPlay.Name = "miPlay";
            this.miPlay.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miPlay.Size = new System.Drawing.Size(156, 22);
            this.miPlay.Text = "&Play";
            this.miPlay.Click += new System.EventHandler(this.miPlay_Click);
            // 
            // miFullScreen
            // 
            this.miFullScreen.Name = "miFullScreen";
            this.miFullScreen.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.miFullScreen.Size = new System.Drawing.Size(156, 22);
            this.miFullScreen.Text = "&Full Screen";
            this.miFullScreen.Click += new System.EventHandler(this.miFullScreen_Click);
            // 
            // miReorder
            // 
            this.miReorder.Name = "miReorder";
            this.miReorder.Size = new System.Drawing.Size(156, 22);
            this.miReorder.Text = "&Reorder";
            this.miReorder.Click += new System.EventHandler(this.miReorder_Click);
            // 
            // miMedia
            // 
            this.miMedia.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPrint,
            this.miSaveVisionBoardImage,
            this.miWallpaper,
            this.miScreensaver});
            this.miMedia.Name = "miMedia";
            this.miMedia.Size = new System.Drawing.Size(52, 20);
            this.miMedia.Text = "&Media";
            // 
            // miPrint
            // 
            this.miPrint.Name = "miPrint";
            this.miPrint.Size = new System.Drawing.Size(200, 22);
            this.miPrint.Text = "&Print";
            this.miPrint.Click += new System.EventHandler(this.miPrint_Click);
            // 
            // miSaveVisionBoardImage
            // 
            this.miSaveVisionBoardImage.Name = "miSaveVisionBoardImage";
            this.miSaveVisionBoardImage.Size = new System.Drawing.Size(200, 22);
            this.miSaveVisionBoardImage.Text = "Save &VisionBoard &Image";
            this.miSaveVisionBoardImage.Click += new System.EventHandler(this.miSaveVisionBoardImage_Click);
            // 
            // miWallpaper
            // 
            this.miWallpaper.Name = "miWallpaper";
            this.miWallpaper.Size = new System.Drawing.Size(200, 22);
            this.miWallpaper.Text = "Set as &Wallpaper";
            this.miWallpaper.Click += new System.EventHandler(this.miWallpaper_Click);
            // 
            // miScreensaver
            // 
            this.miScreensaver.Name = "miScreensaver";
            this.miScreensaver.Size = new System.Drawing.Size(200, 22);
            this.miScreensaver.Text = "Set as &Screensaver";
            this.miScreensaver.Click += new System.EventHandler(this.miScreensaver_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInstructions,
            this.miAssocVDB,
            this.miAbout,
            this.miUpdates});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(44, 20);
            this.miHelp.Text = "&Help";
            // 
            // miInstructions
            // 
            this.miInstructions.Name = "miInstructions";
            this.miInstructions.Size = new System.Drawing.Size(180, 22);
            this.miInstructions.Text = "&Instructions";
            this.miInstructions.Click += new System.EventHandler(this.miInstructions_Click);
            // 
            // miAssocVDB
            // 
            this.miAssocVDB.Name = "miAssocVDB";
            this.miAssocVDB.Size = new System.Drawing.Size(180, 22);
            this.miAssocVDB.Text = "Associate .&vbd Files";
            this.miAssocVDB.Click += new System.EventHandler(this.miAssocVBD_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(180, 22);
            this.miAbout.Text = "&About VisionBoard";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miUpdates
            // 
            this.miUpdates.Name = "miUpdates";
            this.miUpdates.Size = new System.Drawing.Size(180, 22);
            this.miUpdates.Text = "Check for &Updates";
            this.miUpdates.Click += new System.EventHandler(this.miUpdates_Click);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
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
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miPlay;
        private System.Windows.Forms.ToolStripMenuItem miFullScreen;
        private System.Windows.Forms.ToolStripMenuItem miInstructions;
        private System.Windows.Forms.ToolStripMenuItem miUpdates;
        private System.Windows.Forms.ToolStripMenuItem miAssocVDB;
        private System.Windows.Forms.ToolStripMenuItem miReorder;
        private System.Windows.Forms.ToolStripMenuItem miMedia;
        private System.Windows.Forms.ToolStripMenuItem miPrint;
        private System.Windows.Forms.ToolStripMenuItem miSaveVisionBoardImage;
        private System.Windows.Forms.ToolStripMenuItem miWallpaper;
        private System.Windows.Forms.ToolStripMenuItem miScreensaver;
    }
}

