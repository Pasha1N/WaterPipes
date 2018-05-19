﻿using System;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class UpArrow : ICommand
    {
        private Cursor cursor;

        public UpArrow(Cursor cursor)
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