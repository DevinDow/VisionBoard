using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevinDow.VisionBoard
{
    public partial class ScreensaverForm : Form
    {
        // Public Properties
        public static string ScreensaverVisionBoardPath
        {
            get
            {
                // Screensaver Visionboard stored at "MyDocuments\VisionBoard.vbd"
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisionBoard.vbd");
            }
        }


        // Private Fields
        private Point mousePoint;


        // Public Constructor
        public ScreensaverForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Cursor.Hide();
        }


        // Private Events
        private void ScreensaverForm_Load(object sender, EventArgs e)
        {
            if (VisionBoard.Current == null)
            {
                string path = ScreensaverVisionBoardPath;
                VisionBoard.Current = vbdFile.Read(path);
                Invalidate();

                if (VisionBoard.Current == null)
                {
                    MessageBox.Show(".VBD file could not be loaded", path);
                    return;
                }
            }

            if (VisionBoard.Current != null)
            {
                VisionBoard.Current.ItemEnumerator = VisionBoard.Current.Items.GetEnumerator();
                VisionBoard.Current.ItemEnumerator.MoveNext();
                VisionBoard.Current.Step = 0;
            }
        }

        private void ScreensaverForm_Paint(object sender, PaintEventArgs e)
        {
            if (VisionBoard.Current != null)
                VisionBoard.Current.Play(e.Graphics, Width, Height);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (VisionBoard.Current == null)
                return;

            VisionBoard.Current.Step++;

            if (VisionBoard.Current.Step >= VisionBoard.MaxStep)
            {
                if (!VisionBoard.Current.ItemEnumerator.MoveNext())
                {
                    VisionBoard.Current.ItemEnumerator.Reset();
                    VisionBoard.Current.ItemEnumerator.MoveNext();
                }
                VisionBoard.Current.Step = 0;
            }

            Invalidate();
        }


        private void ScreensaverForm_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
        private void ScreensaverForm_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        private void ScreensaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePoint.IsEmpty)
                mousePoint = new Point(e.X, e.Y);
            if (Math.Abs(e.X  - mousePoint.X) > 10 || Math.Abs(e.Y  - mousePoint.Y) > 10)
                this.Close();
        }

        private void ScreensaverForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Show();
        }
    }
}
