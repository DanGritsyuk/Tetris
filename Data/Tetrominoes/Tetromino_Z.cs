using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetromino_Z : ITetromino
    {
        public char Name => 'Z';

        private byte[,] _parameters = new byte[,] { { 3, 3, 4, 4 }, { 7, 8, 8, 9 } };
        public byte[,] Parameters { get => _parameters; set => this._parameters = value; }

        public Brush Color => Brushes.Red;

        private bool _isTurned = false;
        public void RotateShape()
        {
            var arrShape = this._parameters;

            if (_isTurned)
            {
                arrShape[1, 0] -= 2;
                arrShape[0, 1]--; arrShape[1, 1]--;
                arrShape[0, 3]--; arrShape[1, 3]++;

                this._isTurned = false;
            }
            else
            {
                arrShape[1, 0] += 2;
                arrShape[0, 1]++; arrShape[1, 1]++;
                arrShape[0, 3]++; arrShape[1, 3]--;

                this._isTurned = true;
            }
        }

        public void ErrRotateShape()
        {
            RotateShape();
        }
    }
}