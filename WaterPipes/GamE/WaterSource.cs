using System;

namespace WaterPipes.Game
{
    internal class WaterSource : PipelineElement
    {
        private char waterSource = 'S';

        public WaterSource(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override void Print()
        {
            Console.SetCursorPosition(Width, Height);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(waterSource);
            Console.ResetColor();
        }
    }
}