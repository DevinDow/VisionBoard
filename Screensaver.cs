﻿using System;
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
                string exePath = asm.Location;
                string scrPath = exePath.Replace(".exe", ".scr");
                File.Copy(exePath, scrPath, true);
                System.Diagnostics.Process.Start(scrPath); // Launch default action on .scr, which is either "Install" or "Test".
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
