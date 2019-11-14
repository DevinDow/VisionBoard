using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing.Imaging;

namespace DevinDow.VisionBoard
{
    public partial class MainForm : Form
    {
        // Public Fields
        public static VisionBoard VisionBoard;

        
        // Private Fields
        private Point clickedPoint;
        private ImageItem selectedItem;
        private bool moving = false;
        private bool rotating = false;
        private bool scaling = false;


        // Constructors
        public MainForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        public MainForm(string path)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            if (path.Length > 0)
                VisionBoard = vbdFile.Read(path);
        }


        // Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (VisionBoard == null)
            {
                VisionBoard = vbdFile.Read(Properties.Settings.Default.CurrentVisionBoardFile);
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (VisionBoard == null)
                return;

            // Set up Bitmap
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics bitmapG = Graphics.FromImage(bitmap);
            bitmapG.SetClip(new Rectangle(0, 0, Width, Height));
            bitmapG.TranslateTransform(Width / 2, Height / 2);

            // Draw Non-Selected to Bitmap
            foreach (ImageItem item in VisionBoard.Items)
                if (item != selectedItem)
                    item.Draw(bitmapG);

            // Draw Selected to Bitmap
            if (selectedItem != null)
                selectedItem.Draw(bitmapG, true);

            // Paint Bitmap
            e.Graphics.DrawImage(bitmap, 0, 0);

            bitmapG.Dispose();
            bitmap.Dispose();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VisionBoard.IsDirty)
                if (MessageBox.Show("Close without saving your VisionBoard?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    e.Cancel = true;
        }


        // Mouse
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            clickedPoint = new Point(e.Location.X - Width / 2, e.Location.Y - Height / 2);

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (selectedItem != null)
                {
                    float xOffset = 1.0f * (clickedPoint.X - selectedItem.X);
                    float yOffset = 1.0f * (clickedPoint.Y - selectedItem.Y);

                    // Scaling
                    if (Math.Abs(xOffset - ((float)Math.Cos(selectedItem.RotationRadians) * selectedItem.Size.Width / 2 - ImageItem.HandleSize)) < 1.5 * ImageItem.HandleSize &&
                            Math.Abs(yOffset - (float)Math.Sin(selectedItem.RotationRadians) * selectedItem.Size.Width / 2) < 1.5 * ImageItem.HandleSize)
                    {
                        scaling = true;
                        return;
                    }

                    // Rotating
                    if (Math.Abs(xOffset - (float)Math.Cos(selectedItem.RotationRadians) * selectedItem.Size.Width / 4) < 1.5 * ImageItem.HandleSize &&
                            Math.Abs(yOffset - (float)Math.Sin(selectedItem.RotationRadians) * selectedItem.Size.Width / 4) < 1.5 * ImageItem.HandleSize)
                    {
                        rotating = true;
                        return;
                    }

                    // Moving
                    if (Math.Abs(xOffset) < 1.5 * ImageItem.HandleSize && Math.Abs(yOffset) < 1.5 * ImageItem.HandleSize)
                    {
                        moving = true;
                        return;
                    }


                    // Deleting
                    if (Math.Abs(xOffset - ((float)Math.Cos(selectedItem.RotationRadians) * selectedItem.Size.Width / 2 + (float)Math.Sin(selectedItem.RotationRadians) * selectedItem.Size.Height / 2 - ImageItem.HandleSize)) < 1.5 * ImageItem.HandleSize &&
                            Math.Abs(yOffset - ((float)Math.Sin(selectedItem.RotationRadians) * selectedItem.Size.Width / 2 - (float)Math.Cos(selectedItem.RotationRadians) * selectedItem.Size.Height / 2 + ImageItem.HandleSize)) < 1.5 * ImageItem.HandleSize)
                    {
                        if (MessageBox.Show("Delete this image?", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            VisionBoard.Items.Remove(selectedItem);
                            selectedItem = null;
                            Invalidate();
                        }
                        return;
                    }
                }

                // Selecting
                selectedItem = null;
                foreach (ImageItem item in VisionBoard.Items)
                    if (item.HitTest(clickedPoint.X, clickedPoint.Y))
                    {
                        if (selectedItem == null)
                            selectedItem = item;
                        else if (item.Distance(clickedPoint.X, clickedPoint.Y) < selectedItem.Distance(clickedPoint.X, clickedPoint.Y))
                            selectedItem = item;
                    }
                Invalidate();
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.Location.X - Width / 2;
            int y = e.Location.Y - Height / 2;

            if (moving)
            {
                selectedItem.X = x;
                selectedItem.Y = y;
                Invalidate();
                VisionBoard.IsDirty = true;
            }

            else if (rotating)
            {
                selectedItem.RotationRadians = (float)Math.Atan2(y - selectedItem.Y, x - selectedItem.X);
                Invalidate();
                VisionBoard.IsDirty = true;
            }

            else if (scaling)
            {
                float newHalfWidth = (float)Math.Sqrt(Math.Pow(x - selectedItem.X, 2) + Math.Pow(y - selectedItem.Y, 2));
                selectedItem.Scale = newHalfWidth / (selectedItem.Image.Width / 2);
                Invalidate();
                VisionBoard.IsDirty = true;
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            rotating = false;
            scaling = false;
        }


        // Menus
        private void miPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                IDataObject data = Clipboard.GetDataObject();
                Bitmap bitmap = (Bitmap)data.GetData(DataFormats.Bitmap);
                ImageItem item = new ImageItem();
                item.Image = bitmap;
                item.X = clickedPoint.X;
                item.Y = clickedPoint.Y;
                item.Filename = VisionBoard.nextIndex++.ToString();
                if (item.Size.Width > Screen.PrimaryScreen.Bounds.Width || item.Size.Height > Screen.PrimaryScreen.Bounds.Height)
                {
                    item.Scale = Math.Min(1f * Screen.PrimaryScreen.Bounds.Width / item.Bounds.Width, 1f * Screen.PrimaryScreen.Bounds.Height / item.Bounds.Height);
                }
                VisionBoard.Items.Add(item);
                Invalidate();
                VisionBoard.IsDirty = true;
            }
            else if (Clipboard.ContainsFileDropList())
            {
                string path = Clipboard.GetFileDropList()[0];

                MessageBox.Show("Open the file in MS Paint\nSelect All (Ctrl+A)\nCopy (Ctrl+C)\n\nPaint will now be launched...", path);

                try
                {
                    System.Diagnostics.Process paint = new System.Diagnostics.Process();
                    paint.StartInfo.FileName = "mspaint.exe";
                    paint.StartInfo.Arguments = "\"" + path + "\"";
                    paint.Start();
                }
                catch (Exception) { }
            }
        }

        
        private void miNew_Click(object sender, EventArgs e)
        {
            VisionBoard = new VisionBoard();
            Invalidate();
            Properties.Settings.Default.CurrentVisionBoardFile = string.Empty;
            Properties.Settings.Default.Save();
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (VisionBoard.Filename != null && VisionBoard.Filename.Length > 0)
                vbdFile.Write(VisionBoard.Filename, VisionBoard);
            else
                vbdFile.Write(VisionBoard);
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            vbdFile.Write(VisionBoard);
        }

        private void miLoad_Click(object sender, EventArgs e)
        {
			VisionBoard newVisionBoard = vbdFile.Read();
			if (newVisionBoard != null)
			{
				VisionBoard = newVisionBoard;
				Invalidate();
			}
        }


        private void miSaveVisionBoardImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".jpg";
            sfd.Filter = "Jpeg File (*.jpg)|*.jpg";
            sfd.FileName = "*.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Rectangle bounds = Screen.PrimaryScreen.Bounds;
                Bitmap bitmap = VisionBoard.GetBitmap(bounds.Width, bounds.Height);
                bitmap.Save(sfd.FileName, ImageFormat.Jpeg);
            }
        }

        private void miWallpaper_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap bitmap = VisionBoard.GetBitmap(bounds.Width, bounds.Height);
            Wallpaper.SetWallpaper(bitmap);

            Cursor = Cursors.Default;
        }

        private void miScreensaver_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                Screensaver.Install();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nTo set up screensaver manually:\n Copy VisionBoard.exe to VisionBoard.scr then r-click.", "Failed to install VisionBoard screen saver.");
            }

            Cursor = Cursors.Default;
        }

        private void miPlay_Click(object sender, EventArgs e)
        {
            ScreensaverForm form = new ScreensaverForm();
            form.VisionBoard = VisionBoard;
            form.Show();
        }

        private void miPrint_Click(object sender, EventArgs e)
        {
            Print print = new Print(VisionBoard);
        }

        private void miFullScreen_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            if (FormBorderStyle == FormBorderStyle.Sizable)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Maximized;
            }
            Invalidate();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void miInstructions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VisionBoard lets you build a Vision Board on your computer\n   using images from the internet or your computer\n   instead of having to cut out magazine clippings\n\n" +
                "Simply find an image on the Internet or MS Word or MS Paint,\n   Right-Click it and select \"Copy\", then Right-Click in\n   VisionBoard where you want to Paste it.\n\n" +
                "You can then animate your Vision Board using the View|Play menu,\n   print your Vision Board, set it as your Windows Background,\n   and set it as your Screen Saver.\n\n" +
                "You can click on an image to move, rotate, scale, or delete it (using the handles).\n\n" +
                "Before you know it, your visions will come to you!\n\n\n" +
                "Enjoy!",
                "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void miAssocVBD_Click(object sender, EventArgs e)
        {
            associateVbdExtension();
        }


        // Methods
        [DllImport("shell32.dll")]
        static extern void SHChangeNotify(long wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        private void associateVbdExtension()
        {
            try
            {
                RegistryKey key = Registry.ClassesRoot.CreateSubKey(".vbd");
                key.SetValue(null, "VisionBoard");
                key.Close();

                key = Registry.ClassesRoot.CreateSubKey("VisionBoard\\Shell\\Open");
                key.SetValue(null, "Open with VisionBoard");
                key.Close();

                key = Registry.ClassesRoot.CreateSubKey("VisionBoard\\Shell\\Open\\Command");
                System.Reflection.Assembly asm = System.Reflection.Assembly.GetEntryAssembly();
                key.SetValue(null, asm.Location + " \"%1\"");
                key.Close();

                key = Registry.ClassesRoot.CreateSubKey("VisionBoard\\DefaultIcon");
                key.SetValue(null, asm.Location + ",0");
                key.Close();


                SHChangeNotify(0x08000000/*SHCNE_ASSOCCHANGED*/, 0x0000/*SHCNF_IDLIST*/, IntPtr.Zero, IntPtr.Zero);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
