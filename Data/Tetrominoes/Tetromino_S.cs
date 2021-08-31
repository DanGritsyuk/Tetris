using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetromino_S : ITetromino
    {
        public char Name => 'S';

        private byte[,] _parameters = new byte[,] { { 3, 3, 4, 4 }, { 9, 8, 8, 7 } };
        public byte[,] Parameters { get => _parameters; set => this._parameters = value; }

        public Brush Color => Brushes.LawnGreen;

        private bool _isTurned = false;
        public void RotateShape()
        {
            var arrShape = this._parameters;

            if (_isTurned)
            {
                arrShape[0, 0]++; arrShape[1, 0]++;
                arrShape[0, 2]++; arrShape[1, 2]--;
                arrShape[1, 3] -= 2;

                this._isTurned = false;
            }
            else
            {
                arrShape[0, 0]--; arrShape[1, 0]--;
                arrShape[0, 2]--; arrShape[1, 2]++;
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

