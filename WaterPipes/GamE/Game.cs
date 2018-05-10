using System.Threading;

namespace WaterPipes.GamE
{
    class Game
    {
        private ArrayOfPipes objectOfPipes = new ArrayOfPipes();
        private ArrayOfSources objectOfSources = new ArrayOfSources();
        private Trumpet[] pipes = null;
        private WaterSource[] sources = null;

        public Game()
        {
            Field field = new Field();
            field.Show();

            InstallationOfPipelineComponents installationOfElements = new InstallationOfPipelineComponents(field, objectOfPipes, objectOfSources);
            installationOfElements.Establish();
            OpenSources();
        }
        public void OpenSources()
        {
            pipes = objectOfPipes.GetPipes();
            sources = objectOfSources.GetSources();

            int height = 0;
            int width = 0;
            int speed = 400;

            for (int i = 0; i < sources.Length; i++)
            {
                if (sources[i] != null)
                {
                    width = sources[i].GetWidth();
                    height = sources[i].GetHeight();

                    for (int j = -1; j < 2; j += 2)
                    {
                        for (int p = 0; p < pipes.Length; p++)
                        {
                            if (pipes[p] != null)
                            {
                                if (pipes[p].GetHeight() == height + j && pipes[p].GetWidth() == width)
                                {
                                    pipes[p].Fill();
                                    pipes[p].Print();
                                }

                                if (pipes[p].GetWidth() == width + j && pipes[p].GetHeight() == height)
                                {
                                    pipes[p].Fill();
                                    pipes[p].Print();
                                }
                            }
                        }
                    }
                }
            }
            Thread.Sleep(speed);

            bool work = true;
            while (work)
            {
                ArrayOfPipes objectTemporaryArray = new ArrayOfPipes();

                for (int l = 0; l < pipes.Length; l++)
                {
                    if (pipes[l] != null)
                    {
                        if (!pipes[l].IsEmpty())
                        {
                            width = pipes[l].GetWidth();
                            height = pipes[l].GetHeight();

                            for (int j = -1; j < 2; j += 2)
                            {
                                for (int p = 0; p < pipes.Length; p++)
                                {
                                    if (pipes[p] != null)
                                    {
                                        if (pipes[p].GetHeight() == height + j && pipes[p].GetWidth() == width)
                                        {
                                            if (pipes[p].IsEmpty())
                                            {
                                                objectTemporaryArray.AddTrumpet(pipes[p]);
                                            }
                                        }

                                        if (pipes[p].GetWidth() == width + j && pipes[p].GetHeight() == height)
                                        {
                                            if (pipes[p].IsEmpty())
                                            {
                                                objectTemporaryArray.AddTrumpet(pipes[p]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (objectTemporaryArray.GetSize() > 0)
                {

                    Trumpet[] temporeryArray = objectTemporaryArray.GetPipes();

                    for (int i = 0; i < temporeryArray.Length; i++)
                    {
                        if (temporeryArray[i] != null)
                        {
                            for (int j = 0; j < pipes.Length; j++)
                            {
                                if (pipes[j] != null)
                                {
                                    if (temporeryArray[i].GetWidth() == pipes[j].GetWidth() && temporeryArray[i].GetHeight() == pipes[j].GetHeight())
                                    {
                                        pipes[j].Fill();
                                        pipes[j].Print();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    work = false;
                }
                objectTemporaryArray = null;
                Thread.Sleep(speed);

            }
        }
    }
}