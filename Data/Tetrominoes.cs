using System;
using System.Drawing;

namespace Tetris
{
    public static class Tetrominoes
    {
        public static Shape TTR_I() => new Shape(Data_I.Item1, (byte[,])Data_I.Item2.Clone(), Data_I.Item3, GetBitmap_I());
        public static Shape TTR_O() => new Shape(Data_O.Item1, (byte[,])Data_O.Item2.Clone(), Data_O.Item3, GetBitmap_O());
        public static Shape TTR_L() => new Shape(Data_L.Item1, (byte[,])Data_L.Item2.Clone(), Data_L.Item3, GetBitmap_L());
        public static Shape TTR_J() => new Shape(Data_J.Item1, (byte[,])Data_J.Item2.Clone(), Data_J.Item3, GetBitmap_J());
        public static Shape TTR_Z() => new Shape(Data_Z.Item1, (byte[,])Data_Z.Item2.Clone(), Data_Z.Item3, GetBitmap_Z());
        public static Shape TTR_S() => new Shape(Data_S.Item1, (byte[,])Data_S.Item2.Clone(), Data_S.Item3, GetBitmap_S());
        public static Shape TTR_T() => new Shape(Data_T.Item1, (byte[,])Data_T.Item2.Clone(), Data_T.Item3, GetBitmap_T());

        private static readonly Tuple<char, byte[,], Brush> Data_I = new Tuple<char, byte[,], Brush>('I', new byte[,] { { 2, 3, 4, 5 }, { 8, 8, 8, 8 } }, Brushes.Aquamarine);
        private static readonly Tuple<char, byte[,], Brush> Data_O = new Tuple<char, byte[,], Brush>('O', new byte[,] { { 2, 3, 2, 3 }, { 8, 8, 9, 9 } }, Brushes.Yellow);
        private static readonly Tuple<char, byte[,], Brush> Data_L = new Tuple<char, byte[,], Brush>('L', new byte[,] { { 2, 3, 4, 4 }, { 8, 8, 8, 9 } }, Brushes.Orange);
        private static readonly Tuple<char, byte[,], Brush> Data_J = new Tuple<char, byte[,], Brush>('J', new byte[,] { { 2, 3, 4, 4 }, { 8, 8, 8, 7 } }, Brushes.DeepSkyBlue);
        private static readonly Tuple<char, byte[,], Brush> Data_Z = new Tuple<char, byte[,], Brush>('Z', new byte[,] { { 3, 3, 4, 4 }, { 7, 8, 8, 9 } }, Brushes.Red);
        private static readonly Tuple<char, byte[,], Brush> Data_S = new Tuple<char, byte[,], Brush>('S', new byte[,] { { 3, 3, 4, 4 }, { 9, 8, 8, 7 } }, Brushes.LawnGreen);
        private static readonly Tuple<char, byte[,], Brush> Data_T = new Tuple<char, byte[,], Brush>('T', new byte[,] { { 3, 4, 4, 4 }, { 8, 7, 8, 9 } }, Brushes.MediumVioletRed);

        private static Bitmap GetBitmap_I() => GetShapeBitmap(Data_I);
        private static Bitmap GetBitmap_O() => GetShapeBitmap(Data_O);
        private static Bitmap GetBitmap_L() => GetShapeBitmap(Data_L);
        private static Bitmap GetBitmap_J() => GetShapeBitmap(Data_J);
        private static Bitmap GetBitmap_Z() => GetShapeBitmap(Data_Z);
        private static Bitmap GetBitmap_S() => GetShapeBitmap(Data_S);
        private static Bitmap GetBitmap_T() => GetShapeBitmap(Data_T);

        private static Bitmap GetShapeBitmap(Tuple<char, byte[,], Brush> dataTetromino)
        {
            var name = dataTetromino.Item1;
            var arr = (byte[,])dataTetromino.Item2.Clone();
            var color = dataTetromino.Item3;

            int[] mapShape;

            if (name == 'I') { mapShape = new int[] { 5, 6, 6, 1 }; }
            else if (name == 'O') { mapShape = new int[] { 4, 4, 7, 1 }; }
            else if (name == 'L') { mapShape = new int[] { 4, 5, 7, 1 }; }
            else if (name == 'J') { mapShape = new int[] { 4, 5, 6, 1 }; }
            else if (name == 'Z') { mapShape = new int[] { 5, 4, 6, 2 }; }
            else if (name == 'S') { mapShape = new int[] { 5, 4, 6, 2 }; }
            else if (name == 'T') { mapShape = new int[] { 5, 4, 6, 2 }; }
            else { throw new Exception("Shape not exist"); }

            int shapeFieldWidth = mapShape[0];
            int shapeFieldHeight = mapShape[1];
            int shiftX = mapShape[2];
            int shiftY = mapShape[3];

            Graphics gr;
            int k = 15;

            Func<byte[,], int> findShapeHeight = (arrBytes) =>
            {
                int shapeHeigth = 0;

                for (int i = 0; i < arrBytes.Length / 2; i++)
                {
                    if (arrBytes[0, i] > shapeHeigth) { shapeHeigth = arrBytes[0, i]; }
                }
                return shapeHeigth;
            };

            var shapeFieldSize = findShapeHeight(arr) + 1;
            Bitmap bitNextShapeField = new Bitmap(shapeFieldWidth * k, shapeFieldHeight * k);

            gr = Graphics.FromImage(bitNextShapeField);
            gr.Clear(Color.Navy);

            for (int i = 0; i < 4; i++)
                gr.FillRectangle(color, (arr[1, i] - shiftX) * k, (arr[0, i] - shiftY) * k, k - 1, k - 1);

            return bitNextShapeField;
        }
    }
}
