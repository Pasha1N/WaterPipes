using System;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class Left : ICommand
    {
        private Cursor cursor;

        public Left(Cursor cursor)
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