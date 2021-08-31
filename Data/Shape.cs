using System.Drawing;

namespace Tetris
{
    public struct Shape
    {
        public readonly char Name;
        public byte[,] Parameters;
        public Brush Color;
        public Bitmap ImgBitmap;

        public Shape(char name, byte[,] parameters, Brush color, Bitmap bitmapShape)
        {
            this.Name = '0';
            this.Parameters = null;
            this.Color = null;
            this.ImgBitmap = null;

            this.Name = name;
            this.Parameters = parameters;
            this.Color = color;
            this.ImgBitmap = bitmapShape;
        }
    }
}
