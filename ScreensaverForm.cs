using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DevinDow.VisionBoard
{
    public partial class ScreensaverForm : Form
    {
        // Public Static Fields
        public static bool PreventSleep = false;
        public static float ScaleFactor = 1.0f;


        // Public Statis Properties
        public static string ScreensaverVisionBoardPath
        {
            get
            {
                // Screensaver Visionboard stored at "MyDocuments\VisionBoard.vbd"
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisionBoard.vbd");
            }
        }


        // Private Fields
        private bool isInPreviewDialog = false;
        private Point mousePoint;


        // Public Constructor
        public ScreensaverForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Cursor.Hide();
        }

        public ScreensaverForm(IntPtr previewWindowHandle) : this() // used to Preview the Screensaver in the Windows Screensaver Dialog's Preview Window
        {
            isInPreviewDialog = true;

            // set previewWindowHandle as the Parent of this
            SetParent(this.Handle, previewWindowHandle);

            // set this as a Child so it closes when Windows Screensaver dialog closes
            SetWindowLong(this.Handle, GWL_STYLE, new IntPtr(GetWindowLong(this.Handle, GWL_STYLE) | WS_CHILD));

            /*// set Size & Location
            Rectangle ParentRect;
            GetClientRect(previewWindowHandle, out ParentRect);
            this.Size = ParentRect.Size;
            this.Location = new Point(0, 0);*/
        }


        // Private Events
        private void ScreensaverForm_Load(object sender, EventArgs e) // Init Sccreensaver
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

            VisionBoard.Current.InitPlaying();

            if (isInPreviewDialog)
                ScaleFactor = Math.Min(1.0f * Width / Screen.PrimaryScreen.Bounds.Width, 1.0f * Height / Screen.PrimaryScreen.Bounds.Height); // Fit the VisionBoard.Bounds within screen (or Windows Screensaver Dialog preview window)
        }

        private void timer_Tick(object sender, EventArgs e) // Advance one Frame
        {
            if (VisionBoard.Current == null)
                return;

            VisionBoard.Current.NextStep();

            Invalidate();

            if (PreventSleep)
                preventSleep();
        }

        private void ScreensaverForm_Paint(object sender, PaintEventArgs e) // Draw a Frame
        {
            if (VisionBoard.Current != null)
                VisionBoard.Current.PlayAStep(e.Graphics, Width, Height);
        }


        // End Screensaver
        private void ScreensaverForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    timer.Enabled = !timer.Enabled; // pause wherever it is
                    break;
                case Keys.Right:
                    VisionBoard.Current.NextItem(); // next Item at Step 0
                    timer.Enabled = true; // only makes sense if it's running
                    break;
                case Keys.Up:
                    timer.Enabled = false; // pause
                    VisionBoard.Current.NextItem(true); // next Item at Max
                    Invalidate();
                    break;
                default:
                    this.Close(); // all other Keys end Screensaver
                    break;
            }
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


        #region preventSleep()
        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
            // Legacy flag, should not be used.
            // ES_USER_PRESENT   = 0x00000004,
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        private void preventSleep()
        {
            if (SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS
                | EXECUTION_STATE.ES_DISPLAY_REQUIRED
                | EXECUTION_STATE.ES_SYSTEM_REQUIRED
                | EXECUTION_STATE.ES_AWAYMODE_REQUIRED) == 0) //Away mode for Windows >= Vista
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS
                    | EXECUTION_STATE.ES_DISPLAY_REQUIRED
                    | EXECUTION_STATE.ES_SYSTEM_REQUIRED); //Windows < Vista, forget away mode
        }
        #endregion


        #region SetParent()
        private const int GWL_STYLE = -16;
        private const int WS_CHILD = 0x40000000;

        // Changes the parent window of the specified child window
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        // Changes an attribute of the specified window
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        // Retrieves information about the specified window
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // Retrieves the coordinates of a window's client area
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
        #endregion
    }
}
