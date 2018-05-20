using System;

namespace WaterPipes.Game
{
    internal class Cursor
    {
        private char cursor = 'X';
        private int x;
        private int y;

        public Cursor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public void Show()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(cursor);
            Console.ResetColor();
        }
    }
}