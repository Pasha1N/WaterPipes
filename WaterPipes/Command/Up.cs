using System;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class Up : ICommand
    {
        private Cursor cursor;

        public Up(Cursor cursor)
        {
            this.cursor = cursor;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (cursor.Y > 1)
                {
                    cursor.Y--;
                }
            }
        }
    }
}