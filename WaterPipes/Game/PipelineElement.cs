﻿namespace WaterPipes.Game
{
    internal abstract class PipelineElement
    {
        private int height;
        private int width;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public abstract void Print();
    }
}