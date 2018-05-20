using System;

namespace WaterPipes.Game
{
    internal class Trumpet : PipelineElement
    {
        private bool empty = true;
        private char trumpet = 'O';

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
            get { return empty; }
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