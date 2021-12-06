﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace DevinDow.VisionBoard
{
    public class VisionBoard
    {
        // Public Static Fields
        public static VisionBoard Current;


        // Public Fields
        public string Filename;
        public int NextIndex = 1;
        public bool IsDirty = false;
        public ArrayList Items = new ArrayList();
        public IEnumerator ItemEnumerator;

        // ticks in ScreenSaver
        public int Step;
        public const int MaxStep = 100; // total number of ticks per picture
        public const int PauseSteps = 20; // ticks to pause
        public const int HalfwayStep = MaxStep / 2 - PauseSteps / 2;

        public bool Reordering = false;
        public int OrderIndex;
        public int ReorderCurrentIndex;


        // Public Properties
        public Box Bounds
        {
            get
            {
                Box bounds = new Box();

                foreach (ImageItem item in Items)
                    bounds.Include(item.Bounds);

                return bounds;
            }
        }


        // Private Fields
        private Bitmap playBitmap;
        private ImageItem currentActiveItem;


        // Private Properties
        private void getPlayBitmap(int width, int height, ImageItem activeItem)
        {
            if (playBitmap != null && activeItem == currentActiveItem)
                return;

            if (playBitmap != null)
                playBitmap.Dispose();
            playBitmap = new Bitmap(width, height);
            currentActiveItem = activeItem;

            Graphics bitmapG = Graphics.FromImage(playBitmap);
            bitmapG.SetClip(new Rectangle(0, 0, width, height));
            bitmapG.TranslateTransform(width / 2, height / 2);
            float bitmapScale = Math.Min(1.0f * width / Bounds.Width, 1.0f * height / Bounds.Height);
            bitmapG.ScaleTransform(bitmapScale, bitmapScale);

            bitmapG.FillRectangle(Brushes.Black, -width / 2, -height / 2, width, height);

            foreach (ImageItem item in Items)
                if (item != activeItem)
                    item.Draw(bitmapG);

            bitmapG.Dispose();
        }


        // Public Methods
        public Bitmap GetBitmap(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.Black, 0, 0, width, height);
            g.TranslateTransform(width / 2, height / 2);
            Draw(g);
            g.Dispose();
            return bitmap;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (ImageItem item in Items)
                item.Draw(g);
        }

        public void Play(Graphics g, int width, int height)
        {
            ImageItem activeItem = (ImageItem)ItemEnumerator.Current;

            // bitmap to draw to and its bitmapG Graphics object
            Bitmap bitmap = new Bitmap(width, height);
            Graphics bitmapG = Graphics.FromImage(bitmap);

            // draw playBitmap of all items except activeItem to bitmapG
            getPlayBitmap(width, height, activeItem);

            bitmapG.SetClip(new Rectangle(0, 0, width, height));
            bitmapG.DrawImage(playBitmap, 0, 0);
            bitmapG.TranslateTransform(width / 2, height / 2);

            // actualStep between original position & zoomed-in position
            int actualStep;
            if (Step < MaxStep / 2 - PauseSteps / 2) // zooming in
                actualStep = Step;
            else if (Step > MaxStep / 2 + PauseSteps / 2) // zooming out
                actualStep = MaxStep - Step;
            else // pausing
                actualStep = MaxStep / 2 - PauseSteps / 2;

            // draw activeItem at its current zoom step to bitmapG

            // offset to accelerate
            //int offset = (int)Math.Round(Math.Sqrt(Math.Pow(HalfMaxStep / 2, 2) - Math.Pow(actualStep - HalfMaxStep / 2, 2))); // offset is in the range of [0..HalfMaxStep], slow moving on the ends and fast moving in the middle

            int x = /*-activeItem.X * offset / HalfMaxStep; //*/(int)Math.Round(Math.Pow((Math.Pow(Math.Abs(activeItem.X), 0.666) / HalfwayStep * actualStep), 1.5));
            if (activeItem.X > 0)
                x = -x;
            int y = /*-activeItem.Y * offset / HalfMaxStep; //*/(int)Math.Round(Math.Pow((Math.Pow(Math.Abs(activeItem.Y), 0.33) / HalfwayStep * actualStep), 3)); //-activeItem.Y * actualStep / HalfMaxStep;
            if (activeItem.Y > 0)
                y = -y;
            float rot = -activeItem.RotationDegrees / HalfwayStep * actualStep;
            float maxScale = Math.Min(width * 0.95f / activeItem.Size.Width, height * 0.95f / activeItem.Size.Height);
            float scale = 1 + (maxScale - 1) * actualStep / HalfwayStep;
            if (scale == 0)
                scale = 1;

            activeItem.Draw(bitmapG, x, y, rot, scale);

            // draw the bitmap to the screen
            g.DrawImage(bitmap, 0, 0);

            bitmapG.Dispose();
        }
    }
}
