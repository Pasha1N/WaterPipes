using System;

namespace WaterPipes.GamE
{
    class ArrayOfSources
    {
        private int sizeArray = 10;
        private int index = -1;
        private WaterSource[] waterSource = null;

        public ArrayOfSources()
        {
            waterSource = new WaterSource[sizeArray];
        }

        public WaterSource[] GetSources()
        {
            return waterSource;
        }

        public int GetSize()
        {
            for (int i = 0; i < waterSource.Length; i++)
            {
                if (waterSource[i] == null)
                {
                    index = i + 1;
                    return index;
                }
            }
            return index;
        }

        public void AddSource(WaterSource trumpet)
        {
            if (GetSize() == sizeArray)
            {
                sizeArray *= 2;
                Array.Resize<WaterSource>(ref waterSource, sizeArray);
            }

            int index = Array.IndexOf(waterSource, null);
            waterSource[index] = trumpet;
        }
    }
}