using System;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class Down : ICommand
    {
        private Cursor cursor;
        private Field field;

        public Down(Cursor cursor, Field field)
        {
            this.cursor = cursor;
            this.field = field;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (cursor.Y < field.Height - 1)
                {
                    cursor.Y++;
                }
            }
        }
    }
}