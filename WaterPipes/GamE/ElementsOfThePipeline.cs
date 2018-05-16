namespace WaterPipes.Game
{
    internal abstract class ElementsOfThePipeline
    {
        protected internal int height;
        protected internal int width;

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public abstract void Print();

    }
}