using System;

namespace WaterPipes.Game
{
    internal class Field
    {
        private int height = 15;
        private int width = 30;
        private char border = '+';

        public void Show()
        {   //(width + 2) увеличение ширины поля 
            for (int i = 0; i < width + 2; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine(border);

                //(height + 1)увеличение длинны поля
                Console.SetCursorPosition(i, height + 1);
                Console.WriteLine(border);
            }

            //(height + 2) увеличение длинны поля
            for (int i = 0; i < height + 2; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(border);

                //(width + 1) увеличение ширины поля
                Console.SetCursorPosition(width + 1, i);
                Console.WriteLine(border);
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }
    }
}