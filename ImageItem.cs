using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;

namespace DevinDow.VisionBoard
{
    class ImageItem
    {
        // Public Constants
        public const int HandleSize = 5;


        // Public Fields
        public int X, Y;
        public float RotationDegrees = 0;
        public float Scale = 1;
        public Image Image;
        public string Filename;
        public string Caption;


        // Public Properties
        public float RotationRadians
        {
            get { return RotationDegrees * (float)Math.PI / 180; }
            set { RotationDegrees = value * 180 / (float)Math.PI; }
        }

        public Size Size
        {
            get { return new Size((int)Math.Round(Image.Width * Scale), (int)Math.Round(Image.Height * Scale)); }
        }

        public Box Bounds
        {
            get
            {
                Size size = Size;
                return new Box(X - size.Width / 2, X + size.Width / 2, Y + size.Height / 2, Y - size.Height / 2);
            }
        }


        // Public Methods
        public void Draw(Graphics g) { Draw(g, 0, 0, 0, 1, false); }
        public void Draw(Graphics g, bool selected) { Draw(g, 0, 0, 0, 1, selected); }
        public void Draw(Graphics g, int x, int y, float rotation, float scale) { Draw(g, x, y, rotation, scale, false); }

        public void Draw(Graphics g, int x, int y, float rotation, float scale, bool selected)
        {
            GraphicsState state = g.Save();
            g.TranslateTransform(X + x, Y + y);
            g.RotateTransform(RotationDegrees + rotation);
            g.ScaleTransform(Scale * scale, Scale * scale);

            // Image
            g.DrawImage(Image, -Image.Width / 2, -Image.Height / 2);

            // Caption
            if (Caption != null && Caption.Length > 0)
            {
                Font font = new Font(FontFamily.GenericSerif, 1.0f * Size.Height / 10);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Far;
                g.DrawString(Caption, font, Brushes.Red, 0, Image.Height / 2, format);
            }

            // Reordering
            float handleSize = 1.0f * HandleSize / Scale;
            if (VisionBoard.Current.Reordering)
            {
                float numSize = handleSize * 4;
                Brush brush = Brushes.Red;
                if (VisionBoard.Current.OrderIndex < VisionBoard.Current.ReorderCurrentIndex)
                    brush = Brushes.Green;
                g.FillRectangle(brush, -numSize, -numSize, numSize * 2, numSize * 2);

                Font font = new Font(FontFamily.GenericSerif, numSize);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(VisionBoard.Current.OrderIndex.ToString(), font, Brushes.Black, 0, 0, format);
                VisionBoard.Current.OrderIndex--;
            }

            // Selected
            else if (selected)
            {
                // Move handle
                g.FillRectangle(Brushes.Orange, -handleSize, -handleSize, handleSize * 2, handleSize * 2);

                // Rotate handle
                g.FillRectangle(Brushes.Orange, Image.Width / 4 - handleSize, -handleSize, handleSize * 2, handleSize * 2); 

                // Scale handle
                g.FillRectangle(Brushes.Orange, Image.Width / 2 - handleSize*2, -handleSize, handleSize * 2, handleSize * 2); 

                // Delete handle
                g.DrawRectangle(Pens.Red, Image.Width / 2 - handleSize * 2, -Image.Height / 2, handleSize * 2, handleSize * 2);
                g.DrawLine(Pens.Red, Image.Width / 2 - handleSize * 2, -Image.Height / 2 + handleSize * 2, Image.Width / 2, -Image.Height / 2);
                g.DrawLine(Pens.Red, Image.Width / 2 - handleSize * 2, -Image.Height / 2, Image.Width / 2, -Image.Height / 2 + handleSize * 2);
            }

            g.Restore(state);
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement("Image");
            writer.WriteAttributeString("filename", Filename);
            writer.WriteAttributeString("x", X.ToString());
            writer.WriteAttributeString("y", Y.ToString());
            writer.WriteAttributeString("rotation", RotationDegrees.ToString());
            writer.WriteAttributeString("scale", Scale.ToString());
            writer.WriteAttributeString("caption", (Caption != null ? Caption.ToString() : string.Empty));
            writer.WriteEndElement();
        }

        public float Distance(int x, int y) { return (float)Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2)); }

        public bool HitTest(int x, int y)
        {
            if (x < X - Size.Width / 2)
                return false;
            if (x > X + Size.Width / 2)
                return false;
            if (y < Y - Size.Height / 2)
                return false;
            if (y > Y + Size.Height / 2)
                return false;
            return true;
        }

    }
}
