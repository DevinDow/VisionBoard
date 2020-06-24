using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace DevinDow.VisionBoard
{
    class Printer
    {
        public static void Print()
        {
            if (VisionBoard.Current == null)
                return;

            PrintDocument doc = new PrintDocument();
            doc.DocumentName = VisionBoard.Current.Filename;
            doc.DefaultPageSettings.Landscape = true;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = doc;
            dialog.ShowDialog();
        }

        private static void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.TranslateTransform(e.PageBounds.Width / 2, e.PageBounds.Height / 2);

            Box bounds = VisionBoard.Current.Bounds;
            float scale = Math.Min(1.0f * e.MarginBounds.Width / bounds.Width, 1.0f * e.MarginBounds.Height / bounds.Height);
            e.Graphics.ScaleTransform(scale, scale);

            VisionBoard.Current.Draw(e.Graphics);
        }
    }
}
