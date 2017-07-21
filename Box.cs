using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevinDow.VisionBoard
{
    public class Box
    {
        // Public Fields
        public int Left, Right, Top, Bottom;


        // Public Properties
        public int Width { get { return Right - Left; } }
        public int Height { get { return Top - Bottom; } }


        // Public Constructors
        public Box() { }

        public Box(int left, int right, int top, int bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }


        // Public Methods
        public void Include(Box box)
        {
            if (box.Left < Left)
                Left = box.Left;
            if (box.Right > Right)
                Right = box.Right;
            if (box.Top > Top)
                Top = box.Top;
            if (box.Bottom < Bottom)
                Bottom = box.Bottom;
        }
    }
}
