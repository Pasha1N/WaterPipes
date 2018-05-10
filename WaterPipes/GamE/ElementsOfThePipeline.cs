namespace WaterPipes.GamE
{
    internal abstract class ElementsOfThePipeline
    {
        protected  int height;
        protected int width;

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public abstract void Print();

    }
}

