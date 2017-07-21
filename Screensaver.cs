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
                File.Copy(asm.Location, Environment.SystemDirectory + "\\VisionBoard.scr", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
