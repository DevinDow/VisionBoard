using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace DevinDow.VisionBoard
{
    class Print
    {
        // Private Fields
        private VisionBoard visionBoard;


        // Constructor
        public Print(VisionBoard visionBoard)
        {
            if (visionBoard == null)
                return;

            this.visionBoard = visionBoard;

            PrintDocument doc = new PrintDocument();
            doc.DocumentName = visionBoard.Filename;
            doc.DefaultPageSettings.Landscape = true;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = doc;
            dialog.ShowDialog();
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.TranslateTransform(e.PageBounds.Width / 2, e.PageBounds.Height / 2);

            Box bounds = visionBoard.Bounds;
            float scale = Math.Min(1.0f * e.MarginBounds.Width / bounds.Width, 1.0f * e.MarginBounds.Height / bounds.Height);
            e.Graphics.ScaleTransform(scale, scale);
            
            visionBoard.Draw(e.Graphics);
        }
    }
}
