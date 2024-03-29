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

        public bool Reordering = false;
        public int OrderIndex;
        public int ReorderCurrentIndex;

        // Private Fields
        // Steps in ScreenSaver
        private int itemIndex;
        private int Step;
        private const int MaxStep = 100; // total number of ticks per picture
        private const int PauseSteps = 20; // ticks to pause
        private const int HalfwayStep = MaxStep / 2 - PauseSteps / 2;


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
        private Bitmap bitmapOfStaticItems;
        private ImageItem currentActiveItem;


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

        public void Draw(Graphics g, object itemToSkip = null)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = Items.Count - 1; i >= 0; i--) // Draw in Reverse Order so First ends up on top
            {
                ImageItem item = (ImageItem)Items[i];
                if (item != itemToSkip)
                    item.Draw(g);
            }
        }

        public void InitPlaying()
        {
            VisionBoard.Current.itemIndex = 0;
            VisionBoard.Current.Step = 0;

            // clear previous bitmapOfStaticItems to generate a new one
            if (bitmapOfStaticItems != null)
            {
                bitmapOfStaticItems.Dispose();
                bitmapOfStaticItems = null;
            }
        }

        public void PlayAStep(Graphics g, int width, int height)
        {
            if (itemIndex >= Items.Count || itemIndex < 0)
                return;
            ImageItem activeItem = (ImageItem)Items[itemIndex];

            // bitmap to draw to and its bitmapG Graphics object
            Bitmap bitmap = new Bitmap(width, height);
            Graphics bitmapG = Graphics.FromImage(bitmap);
            //bitmapG.SetClip(new Rectangle(0, 0, width, height));

            // draw bitmapOfStaticItems of all items except activeItem to bitmapG
            getBitmapOfStaticItems(width, height, activeItem);
            bitmapG.DrawImage(bitmapOfStaticItems, 0, 0);

            bitmapG.TranslateTransform(width / 2, height / 2); // center (0,0)
            bitmapG.ScaleTransform(ScreensaverForm.ScaleFactor, ScreensaverForm.ScaleFactor); // Scale down to fit

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
            float maxScale = Math.Min(width * 0.95f / ScreensaverForm.ScaleFactor / activeItem.Size.Width, height * 0.95f / ScreensaverForm.ScaleFactor / activeItem.Size.Height);
            float scale = 1 + (maxScale - 1) * actualStep / HalfwayStep;
            if (scale == 0)
                scale = 1;

            activeItem.Draw(bitmapG, x, y, rot, scale);

            // draw the bitmap to the screen
            g.DrawImage(bitmap, 0, 0);

            bitmapG.Dispose();
        }

        public void NextStep()
        {
            if (Step < VisionBoard.MaxStep)
                Step++;
            else
            {
                NextItem();
                Reset();
            }
        }

        public void NextItem()
        {
            itemIndex++;
            if (itemIndex >= Items.Count)
                itemIndex = 0;
        }

        public void PrevItem()
        {
            itemIndex--;
            if (itemIndex < 0)
                itemIndex = Items.Count-1;
        }

        public void Reset()
        {
            Step = 0;
        }

        public void Maximize()
        {
            Step = MaxStep / 2;
        }


        // Private Methods
        private void getBitmapOfStaticItems(int width, int height, ImageItem activeItem)
        {
            // Only generate bitmapOfStaticItems once for all placements of activeItem
            if (bitmapOfStaticItems != null && activeItem == currentActiveItem)
                return;

            if (bitmapOfStaticItems != null)
                bitmapOfStaticItems.Dispose(); // Only Dispose() when generating next bitmapOfStaticItems
            bitmapOfStaticItems = new Bitmap(width, height);
            currentActiveItem = activeItem;

            Graphics bitmapG = Graphics.FromImage(bitmapOfStaticItems);
            bitmapG.SetClip(new Rectangle(0, 0, width, height));
            bitmapG.TranslateTransform(width / 2, height / 2); // center (0,0)
            bitmapG.ScaleTransform(ScreensaverForm.ScaleFactor, ScreensaverForm.ScaleFactor); // Scale down to fit 

            Draw(bitmapG, activeItem);

            bitmapG.Dispose();
        }
    }
}
