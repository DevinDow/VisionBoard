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

                if (args.Length == 0)
                    Application.Run(new MainForm());
                else
                {
                    char argParam = args[0].Trim().ToLower()[1];
                    switch (argParam)
                    {
                        case 's': // Execute Screensaver
                            Cursor.Hide();
                            Application.Run(new ScreensaverForm());
                            break;

                        case 'p': // Execute Preview - involves creating and joining threads
                            break;

                        case 'c': // Options Dialog
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
