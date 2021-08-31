using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetromino_L : ITetromino
    {
        public char Name => 'L';

        private byte[,] _parameters = new byte[,] { { 2, 3, 4, 4 }, { 8, 8, 8, 9 } };
        public byte[,] Parameters { get => _parameters; set => this._parameters = value; }

        public Brush Color => Brushes.Orange;

        private byte _position = 0;
        public void RotateShape()
        {
            var arr = this._parameters;

            if (_position == 0)
            {
                arr[0, 0]++; arr[1, 0]++;
                arr[0, 2]--; arr[1, 2]--;
                arr[1, 3] -= 2;

                this._position = 1;
            }
            else if (_position == 1)
            {
                arr[0, 0]++; arr[1, 0]--;
                arr[0, 2]--; arr[1, 2]++;
                arr[0, 3] -= 2;

                this._position = 2;
            }
            else if (_position == 2)
            {
                arr[0, 0]--; arr[1, 0]++;
                arr[0, 2]++; arr[1, 2]--;
                arr[1, 3] += 2;

                this._position = 3;
            }
            else if (_position == 3)
            {
                arr[0, 0]--; arr[1, 0]--;
                arr[0, 2]++; arr[1, 2]++;
                arr[0, 3] += 2;

                this._position = 0;
            }

        }

        public void ErrRotateShape()
        {
            var arr = this._parameters;

            if (_position == 3)
            {
                arr[0, 0]++; arr[1, 0]--;
                arr[0, 2]--; arr[1, 2]++;
                arr[1, 3] -= 2;

                this._position = 2;
            }
            else if (_position == 1)
            {
                arr[0, 0]--; arr[1, 0]--;
                arr[0, 2]++; arr[1, 2]++;
                arr[1, 3] += 2;

                this._position = 0;
            }
        }
    }
}

//     - 0 -      - 1 -      - 2 -      - 3 -
//   - - - - -  - - - - -  - - - - -  - - - - -
//   - - * - -  - - - - -  - * * - -  - - - * -
//   - - * - -  - * * * -  - - * - -  - * * * -
//   - - * * -  - * - - -  - - * - -  - - - - -
//   - - - - -  - - - - -  - - - - -  - - - - -