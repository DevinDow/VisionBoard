using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DevinDow.VisionBoard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Properties.Settings.Default.Upgrade();

                if (args.Length == 0) // run full VisionBoard editing app
                    Application.Run(new MainForm());
                else
                {
                    char argParam = args[0].Trim().ToLower()[1]; // "/s" or "/w" or "/p" "HWND" or "/c:HWND"
                    switch (argParam)
                    {
                        case 's': // Execute Screensaver
                            Cursor.Hide();
                            Application.Run(new ScreensaverForm());
                            break;

                        case 'w': // Wake = execute Screensaver while preventing Sleep
                            ScreensaverForm.PreventSleep = true;
                            Cursor.Hide();
                            Application.Run(new ScreensaverForm());
                            break;

                        case 'p': // Execute Preview in Preview Window - involves creating and joining threads
                            IntPtr previewHandle = new IntPtr(long.Parse(args[1]));
                            new ScreensaverForm(previewHandle).ShowDialog();
                            break;

                        case 'c': // Options Dialog
                            Application.Run(new MainForm(ScreensaverForm.ScreensaverVisionBoardPath));
                            break;

                        default:
                            Application.Run(new MainForm(args[0]));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
