﻿using System.Collections.Generic;
using System.Threading;

namespace WaterPipes.Game
{
    internal class StartGame
    {
        private List<Trumpet> pipes = new List<Trumpet>();
        private List<WaterSource> sources = new List<WaterSource>();

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

            for (int i = 0; i < sources.Count; i++)
            {
                if (sources[i] != null)
                {
                    width = sources[i].Width;
                    height = sources[i].Height;

                    for (int j = -1; j < 2; j += 2)
                    {
                        for (int p = 0; p < pipes.Count; p++)
                        {
                            if (pipes[p] != null)
                            {
                                if (pipes[p].Height == height + j && pipes[p].Width == width)
                                {
                                    pipes[p].Fill();
                                    pipes[p].Print();
                                }

                                if (pipes[p].Width == width + j && pipes[p].Height == height)
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
                List<Trumpet> fullPipes = new List<Trumpet>();

                for (int l = 0; l < pipes.Count; l++)
                {
                    if (pipes[l] != null)
                    {
                        if (!pipes[l].IsEmpty)
                        {
                            width = pipes[l].Width;
                            height = pipes[l].Height;

                            for (int j = -1; j < 2; j += 2)
                            {
                                for (int p = 0; p < pipes.Count; p++)
                                {
                                    if (pipes[p] != null)
                                    {
                                        if (pipes[p].Height == height + j && pipes[p].Width == width)
                                        {
                                            if (pipes[p].IsEmpty)
                                            {
                                                fullPipes.Add(pipes[p]);
                                            }
                                        }

                                        if (pipes[p].Width == width + j && pipes[p].Height == height)
                                        {
                                            if (pipes[p].IsEmpty)
                                            {
                                                fullPipes.Add(pipes[p]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (fullPipes.Count > 0)
                {
                    for (int i = 0; i < fullPipes.Count; i++)
                    {
                        if (fullPipes[i] != null)
                        {
                            for (int j = 0; j < pipes.Count; j++)
                            {
                                if (pipes[j] != null)
                                {
                                    if (fullPipes[i].Width == pipes[j].Width && fullPipes[i].Height == pipes[j].Height)
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
                fullPipes = null;
                Thread.Sleep(speed);
            }
        }
    }
}