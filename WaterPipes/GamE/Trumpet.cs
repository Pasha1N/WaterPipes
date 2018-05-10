using System;

namespace WaterPipes.GamE
{
    internal class Trumpet : ElementsOfThePipeline
    {
        private char trumpet = 'O';
        private bool empty = true;

        public Trumpet(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Fill()
        {
            empty = false;
        }

        public bool IsEmpty()
        {
            return empty;
        }

        public override void Print()
        {
            Console.SetCursorPosition(width, height);
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