using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Gameplay : IDisposable
    {
        private ITetromino nextShape;
        private ITetromino currentShape;

        private int[,] field = new int[width, height]; // Массив для хранения поля

        private const int width = 15, height = 25, k = 15, // Размеры поля и размер клетки в пикселях
            startSpeed = 500, fastSpeed = 50; // Скорость игры

        private int score = 0, gameSpeed = startSpeed, level = 1; // счет, скорость и уровень

        private int lines = 0;
        private int expMomultiplier = 0;

        private GameControlKeys _lastkeyStatus;

        private bool _pauseGame = false;
        public bool PauseGame
        {
            get { return _pauseGame; }
            set { _pauseGame = value; }
        }

        

        public Gameplay()
        {
            SetShape();
        }

        /// <summary>
        /// Формирование и отображение "кадра"
        /// </summary>
        public Bitmap FillField() //Рисуем "стакан" в котором будут распологаться объекты
        {
            Bitmap bitfield = new Bitmap(k * (width + 1) + 1, k * (height + 3) + 1); //Создаем изображение с размерами (k*(widht)+1) и k*(height + 3) +1
            Graphics gr; // Для рисования поля на PictureBox

            gr = Graphics.FromImage(bitfield);
            gr.Clear(Color.Navy); //Заливаем цветом
            gr.DrawRectangle(new Pen(nextShape.Color), k, k, (width - 1) * k, (height - 1) * k); // рамка
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    gr.FillRectangle(Brushes.Green, i * k, j * k, (k - 1) * field[i, j], (k - 1) * field[i, j]); // рисует постройку
            for (int i = 0; i < 4; i++)
                gr.FillRectangle(currentShape.Color, currentShape.Parameters[1, i] * k, currentShape.Parameters[0, i] * k, k - 1, k - 1); // рисует фигуру
            return bitfield; // отображаем кадр
        }

        /// <summary>
        /// Получить изображение сл. фигуры
        /// </summary>
        /// <returns></returns>
        public Bitmap FillNextShape()
        {
            var name = nextShape.Name;
            var arr = nextShape.Parameters;
            var color = nextShape.Color;

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

        /// <summary>
        /// Изменение состояния в один "тик" игрового времени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GameplayTick()
        {
            var lineFull = (from i in Enumerable.Range(0, field.GetLength(1))
                            where (Enumerable.Range(0, field.GetLength(0)).Select(j => field[j, i]).Sum() >= width - 1)
                            select i).ToArray().Take(1);

            if (lineFull.Count() > 0)
            {
                foreach (int i in lineFull)
                {
                    lines++;
                    expMomultiplier++;

                    for (int k = i; k > 1; k--)
                        for (int l = 1; l < width; l++)
                            field[l, k] = field[l, k - 1];
                }
            }
            else
            {
                if (expMomultiplier > 0)
                {
                    switch (expMomultiplier)
                    {
                        case 1: score += (level - 1) * 4 + 4; break;
                        case 2: score += (level - 1) * 10 + 10; break;
                        case 3: score += (level - 1) * 30 + 30; break;
                        case 4: score += (level - 1) * 120 + 120; break;
                    }

                    expMomultiplier = 0;
                    if (lines >= level * 10) { LevelUp(); }
                }
            }
            Move(0, 1);
        }

        /// <summary>
        /// Нажатие клавиши на клавиатуре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void KeyDown(GameControlKeys key)
        {
            switch (key)
            {
                case GameControlKeys.Left: if (!this._pauseGame) Move(-1, 0); break;
                case GameControlKeys.Rigth: if (!this._pauseGame) Move(1, 0); break;
                case GameControlKeys.Rotate: if (!this._pauseGame) { if (_lastkeyStatus != key)  RotateShape(); } break;
                case GameControlKeys.Down: { gameSpeed = fastSpeed; } break;
                case GameControlKeys.Pause: _pauseGame = !_pauseGame; break;
                default: gameSpeed = startSpeed - (20 * level); break;
            }

            _lastkeyStatus = key;
        }

        /// <summary>
        /// Процедура вызова фигур
        /// </summary>
        public void SetShape()
        {
            if (currentShape == null)
            {
                currentShape = CreatorShapeQueue.GetRandomShape();
                nextShape = CreatorShapeQueue.GetRandomShape();

                if (currentShape.Name == nextShape.Name)
                {
                    Random x = new Random();
                    switch (x.Next(4))
                    {
                        case 0:
                        case 1:
                        case 2: nextShape = CreatorShapeQueue.GetAnotherShape(nextShape.Name); break;
                        case 3: break;
                    }
                }
            }
            else
            {
                currentShape = nextShape;
                nextShape = CreatorShapeQueue.GetRandomShape();
            }
        }

        /// <summary>
        /// Получить текущую скорость игры
        /// </summary>
        public int GetGameSpeed() => gameSpeed;

        public int GetLevel() => level;

        public int GetScore() => score;

        private void Move(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                currentShape.Parameters[1, i] = (byte)(currentShape.Parameters[1, i] + x);
                currentShape.Parameters[0, i] = (byte)(currentShape.Parameters[0, i] + y);
            }

            if (FindMistake())
            {
                Move(-x, -y);
                if (y != 0)
                {
                    for (int i = 0; i < 4; i++)
                        field[currentShape.Parameters[1, i], currentShape.Parameters[0, i]]++;
                    SetShape();
                }
            }
        }

        /// <summary>
        /// проверка на выход за пределы игрового поля
        /// </summary>
        /// <returns></returns>
        private bool FindMistake()
        {
            for (int i = 0; i < 4; i++)
                if (currentShape.Parameters[1, i] >= width ||
                    currentShape.Parameters[0, i] >= height ||
                    currentShape.Parameters[1, i] <= 0 ||
                    currentShape.Parameters[0, i] <= 0 ||
                    field[currentShape.Parameters[1, i],
                    currentShape.Parameters[0, i]] == 1)
                { return true; }
            return false;
        }

        /// <summary>
        /// Повышение уровня
        /// </summary>
        private void LevelUp()
        {
            level++;
            if (gameSpeed != 60) { gameSpeed -= 20; }
        }

        /// <summary>
        /// Повернуть фигуру
        /// </summary>
        private void RotateShape()
        {
            currentShape.RotateShape();
            if (FindMistake()) { currentShape.ErrRotateShape(); }
        }

        private void FastMoveDown()
        {

        }

        public void Dispose()
        {
            nextShape = null;
            currentShape = null;
            field = null;
        }

        public void Tick()
        {
            if (this.PauseGame) { return; }
            this.GameplayTick();
        }
    }
}
