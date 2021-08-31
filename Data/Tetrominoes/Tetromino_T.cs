using System.Drawing;
namespace Tetris
{
    class Tetromino_T : ITetromino
    {
        public char Name => 'T';

        private byte[,] _parameters = new byte[,] { { 4, 3, 3, 3 }, { 8, 7, 8, 9 } };
        public byte[,] Parameters { get => _parameters; set => this._parameters = value; }

        public Brush Color => Brushes.MediumVioletRed;

        private byte _position = 0;
        public void RotateShape()
        {
            var arr = this._parameters;
            if (_position == 0)
            {
                arr[0, 0]--; arr[1, 0]++;
                arr[0, 1]++; arr[1, 1]++;
                arr[0, 3]--; arr[1, 3]--;

                this._position = 1;
            }
            else if (_position == 1)
            {
                arr[0, 0]--; arr[1, 0]--;
                arr[0, 1]--; arr[1, 1]++;
                arr[0, 3]++; arr[1, 3]--;

                this._position = 2;
            }
            else if (_position == 2)
            {
                arr[0, 0]++; arr[1, 0]--;
                arr[0, 1]--; arr[1, 1]--;
                arr[0, 3]++; arr[1, 3]++;

                this._position = 3;
            }
            else if (_position == 3)
            {
                arr[0, 0]++; arr[1, 0]++;
                arr[0, 1]++; arr[1, 1]--;
                arr[0, 3]--; arr[1, 3]++;

                this._position = 0;
            };
        }


        public void ErrRotateShape()
        {
            var arr = this._parameters;
            if (_position == 2)
            {
                arr[0, 0]++; arr[1, 0]++;
                arr[0, 1]++; arr[1, 1]--;
                arr[0, 3]--; arr[1, 3]++;

                this._position = 1;
            }
            else if (_position == 0)
            {
                arr[0, 0]--; arr[1, 0]--;
                arr[0, 1]--; arr[1, 1]++;
                arr[0, 3]++; arr[1, 3]--;

                this._position = 3;
            };
        }
    }
}

//     - 0 -      - 1 -      - 2 -      - 3 -
//   - - - - -  - - - - -  - - - - -  - - - - -
//   - - - - -  - - * - -  - - * - -  - - * - -
//   - * * * -  - - * * -  - * * * -  - * * - -
//   - - * - -  - - * - -  - - - - -  - - * - -
//   - - - - -  - - - - -  - - - - -  - - - - -
