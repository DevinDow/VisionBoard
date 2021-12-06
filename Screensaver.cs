using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DevinDow.VisionBoard
{
    class Screensaver
    {
        internal static void Install()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetEntryAssembly();
        
            try
            {
                // create .SCR from .EXE
                string exePath = asm.Location;
                string scrPath = exePath.Replace(".exe", ".scr");
                File.Copy(exePath, scrPath, true);

                // write current VisionBoard to ScreensaverVisionBoardPath
                vbdFile.Write(ScreensaverForm.ScreensaverVisionBoardPath, VisionBoard.Current);

                // launch default action on .scr, which is either "Install" or "Test"  (This will set this binary as the bits to be run, so this is needed on each new build.)
                System.Diagnostics.Process.Start(scrPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
