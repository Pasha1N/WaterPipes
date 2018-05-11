namespace WaterPipes.Game
{
    internal abstract class ElementsOfThePipeline
    {
        protected int height;
        protected int width;

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