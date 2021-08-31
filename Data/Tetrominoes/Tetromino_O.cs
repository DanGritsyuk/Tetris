using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetromino_O : ITetromino
    {
        public char Name => 'O';

        private byte[,] _parameters = new byte[,] { { 2, 3, 2, 3 }, { 8, 8, 9, 9 } };
        public byte[,] Parameters { get => _parameters; set => this._parameters = value; }

        public Brush Color => Brushes.Yellow;

        public void RotateShape()
        {
            
        }

        public void ErrRotateShape()
        {
            
        }
    }
}
