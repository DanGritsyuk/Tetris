using System;

namespace Tetris
{
    public static class CreatorShapeQueue
    {
        public static ITetromino GetRandomShape()
        {
            ITetromino shape;

            Random x = new Random(DateTime.Now.Millisecond);
            switch (x.Next(7))
            {
                case 0: shape = new Tetromino_I(); break;
                case 1: shape = new Tetromino_O(); break;
                case 2: shape = new Tetromino_L(); break;
                case 3: shape = new Tetromino_J(); break;
                case 4: shape = new Tetromino_Z(); break;
                case 5: shape = new Tetromino_S(); break;
                case 6: shape = new Tetromino_T(); break;
                default: throw new IndexOutOfRangeException("Random index shape not exist");
            }
            return shape;
        }

        public static ITetromino GetAnotherShape(char name)
        {
            ITetromino shape = GetRandomShape();

            if (shape.Name == name) { shape = GetAnotherShape(name); }
            return shape;
        }
    }
}
