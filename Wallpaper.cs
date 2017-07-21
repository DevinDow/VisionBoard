using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DevinDow.VisionBoard
{
    class Wallpaper
    {
        private const int SPI_SETDESKWALLPAPER = 0X14;
        private const int SPIF_UPDATEINIFILE = 0X1;
        private const int SPIF_SENDWININICHANGE = 0X2;

        [DllImport("USER32.DLL", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        // change this to whatever filename you want to use
        private const string WallpaperFile = "VisionBoard.bmp";

        // <SUMMARY>
        // Sets the background of your Windows desktop.  
        // The image will be saved in MyPictures and the background 
        // wallpaper updated.
        // </SUMMARY>
        // The image to be set as the background.
        // <REMARKS></REMARKS>
        internal static void SetWallpaper(Image img)
        {
            string imageLocation;
            imageLocation = System.IO.Path.GetFullPath(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + "\\" + WallpaperFile);
            try
            {
                img.Save(imageLocation, System.Drawing.Imaging.ImageFormat.Bmp);
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLocation, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }

            catch (Exception Ex)
            {
                MessageBox.Show("There was an error setting the wallpaper: " + Ex.Message);
            }
        }
    }
}
