using System.Drawing;

namespace Tetris
{
    class Tetromino_I : ITetromino
    {
        public char Name => 'I';

        public Brush Color => Brushes.Aquamarine;

        private byte[,] _parameters = new byte[,] { { 2, 3, 4, 5 }, { 8, 8, 8, 8 } };
        public byte[,] Parameters { get => _parameters; set => this._parameters = value; }

        private bool _isTurned = false;
        public void RotateShape()
        {
            var arrShape = this._parameters;
            if (_isTurned)
            {
                arrShape[0, 0] -= 1;
                arrShape[0, 2] += 1;
                arrShape[0, 3] += 2;
                arrShape[1, 0] = arrShape[1, 2] = arrShape[1, 3] = arrShape[1, 1];

                this._isTurned = false;
            }
            else
            {
                arrShape[0, 0] = arrShape[0, 2] = arrShape[0, 3] = arrShape[0, 1];
                arrShape[1, 0] -= 1;
                arrShape[1, 2] += 1;
                arrShape[1, 3] += 2;

                this._isTurned = true;
            }

        }

        public void ErrRotateShape()
        {
            RotateShape();
        }
    }
}
