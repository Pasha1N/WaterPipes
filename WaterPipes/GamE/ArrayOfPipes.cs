using System;

namespace WaterPipes.GamE 
{
    class ArrayOfPipes
    {
        private int sizeArray = 10;
        private int index = -1;
        private Trumpet[] arrayOfPipes = null;

        public ArrayOfPipes()
        {
            arrayOfPipes = new Trumpet[sizeArray];
        }

        public Trumpet[] GetPipes()
        {
            return arrayOfPipes;
        }

        public int GetSize()
        {
            for (int i = 0; i < arrayOfPipes.Length; i++)
            {
                if (arrayOfPipes[i] == null)
                {
                    index = i + 1;
                    return index;
                }
            }
            return index;
        }

        public void AddTrumpet(Trumpet trumpet)
        {
            if (GetSize() == sizeArray)
            {
                sizeArray *= 2;
                Array.Resize<Trumpet>(ref arrayOfPipes, sizeArray);
            }

            int index = Array.IndexOf(arrayOfPipes, null);
            arrayOfPipes[index] = trumpet;
        }
    }
}