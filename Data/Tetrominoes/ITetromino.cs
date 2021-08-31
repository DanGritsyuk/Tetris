using System.Drawing;

namespace Tetris
{
    public interface ITetromino
    {
        char Name { get; }
        byte[,] Parameters { get; set; }
        Brush Color { get; }

        void RotateShape();
        void ErrRotateShape();
    }
}
