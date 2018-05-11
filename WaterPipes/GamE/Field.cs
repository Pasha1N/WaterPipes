using System;

namespace WaterPipes.GamE
{
    class Field
    {
        private int height = 15;
        private int width = 30;

        public void Show()
        {
            for (int i = 0; i < width + 2; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("+");

                Console.SetCursorPosition(i,height+1);
                Console.WriteLine("+");
            }

            for (int i = 0; i < height + 2; i++)
            {
                Console.SetCursorPosition (0,i);
                Console.WriteLine("+");

                Console.SetCursorPosition(width+1, i);
                Console.WriteLine("+");
            }
            Console.SetCursorPosition(0, 20);
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