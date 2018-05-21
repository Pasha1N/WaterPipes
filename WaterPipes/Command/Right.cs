using System;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class Right : ICommand
    {
        private Cursor cursor;
        private Field field;

        public Right(Cursor cursor, Field field)
        {
            this.field = field;
            this.cursor = cursor;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (cursor.X < field.Width)
                {
                    cursor.X++;
                }
            }
        }
    }
}