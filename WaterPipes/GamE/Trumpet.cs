﻿using System;

namespace WaterPipes.Game
{
    internal class Trumpet : ElementsOfThePipeline
    {
        private char trumpet = 'O';
        private bool empty = true;

        public Trumpet(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Fill()
        {
            empty = false;
        }

        public bool IsEmpty
        {
            get
            {
                return empty;
            }
        }

        public override void Print()
        {
            Console.SetCursorPosition(Width, Height);
            if (!empty)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(trumpet);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(trumpet);
            }
        }
    }
}