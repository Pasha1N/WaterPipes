using System.Collections.Generic;
using System.Threading;

namespace WaterPipes.Game
{
    internal class StartGame
    {
        private IList<Trumpet> pipes = new List<Trumpet>();
        private IList<WaterSource> sources = new List<WaterSource>();

        public StartGame()
        {
            Field field = new Field();
            field.Show();
            InstallationOfPipelineComponents installationOfElements = new InstallationOfPipelineComponents(field, pipes, sources);
            installationOfElements.Establish();
            OpenSources();
        }

        public void OpenSources()
        {
            int height;
            int width;
            int speed = 400;

            foreach (WaterSource source in sources)
            {
                width = source.Width;
                height = source.Height;

                for (int j = -1; j < 2; j += 2)
                {
                    foreach (Trumpet pipe in pipes)
                    {
                        if (pipe.Height == height + j && pipes[p].Width == width)
                        {
                            pipe.Fill();
                            pipe.Print();
                        }

                        if (pipe.Width == width + j && pipes[p].Height == height)
                        {
                            pipe.Fill();
                            pipe.Print();
                        }
                    }
                }
            }

            Thread.Sleep(speed);
            bool work = true;

            while (work)
            {
                List<Trumpet> fullPipes = new List<Trumpet>();

                foreach (Trumpet pipe in pipes)
                {
                    if (!pipe.IsEmpty)
                    {
                        width = pipe.Width;
                        height = pipe.Height;

                        for (int j = -1; j < 2; j += 2)
                        {
                            foreach (Trumpet trumpet in pipes)
                            {
                                if (trumpet.Height == height + j && trumpet.Width == width)
                                {
                                    if (trumpet.IsEmpty)
                                    {
                                        fullPipes.Add(trumpet);
                                    }
                                }

                                if (trumpet.Width == width + j && trumpet.Height == height)
                                {
                                    if (trumpet.IsEmpty)
                                    {
                                        fullPipes.Add(trumpet);
                                    }
                                }
                            }
                        }
                    }
                }

                if (fullPipes.Count > 0)
                {
                    foreach (Trumpet pipe in fullPipes)
                    {
                        foreach (Trumpet trumpet in pipes)
                        {
                            if (pipe.Width == trumpet.Width && pipe.Height == trumpet.Height)
                            {
                                trumpet.Fill();
                                trumpet.Print();
                            }
                        }
                    }
                }
                else
                {
                    work = false;
                }
                fullPipes = null;
                Thread.Sleep(speed);
            }
        }
    }
}