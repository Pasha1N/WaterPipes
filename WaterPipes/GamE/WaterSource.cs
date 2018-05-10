using System;

namespace WaterPipes.GamE
{
    internal class WaterSource : ElementsOfThePipeline
    {
        private char waterSource = 'S';

        public WaterSource(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override void Print()
        {
            Console.SetCursorPosition(width, height);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(waterSource);
            Console.ResetColor();
        }
    }
}