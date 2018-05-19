using System;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class LeftArrow : ICommand
    {
        private Cursor cursor;

        public LeftArrow(Cursor cursor)
        {
            this.cursor = cursor;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (cursor.X > 1)
                {
                    cursor.X--;
                }
            }
        }
    }
}