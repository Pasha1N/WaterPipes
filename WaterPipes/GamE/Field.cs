using System;

namespace WaterPipes.Game
{
    class Field
    {
        private int height = 15;
        private int width = 30;
        private char border = '+';

        public void Show()
        {
            for (int i = 0; i < width + 2; i++)//(width + 2) увеличение ширины поля 
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine(border);

                Console.SetCursorPosition(i, height + 1); //(height + 1)увеличение длинны поля
                Console.WriteLine(border);
            }

            for (int i = 0; i < height + 2; i++)//(height + 2) увеличение длинны поля
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(border);

                Console.SetCursorPosition(width + 1, i);//(width + 1) увеличение ширины поля
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