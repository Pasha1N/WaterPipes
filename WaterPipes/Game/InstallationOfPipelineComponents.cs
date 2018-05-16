﻿using System;
using System.Collections.Generic;

namespace WaterPipes.Game
{
    internal class InstallationOfPipelineComponents
    {
        private char cursor = 'X';
        private int height = 1;
        private int width = 1;
        private Field field;
        private List<Trumpet> pipes;
        private List<WaterSource> sources;

        public InstallationOfPipelineComponents(Field field, IEnumerable<Trumpet> pipes, List<WaterSource> sources)
        {
            this.pipes = (List<Trumpet>)pipes;
            this.sources = sources;
            this.field = field;
        }

        public void Establish()
        {
            ConsoleKeyInfo key;
            Console.SetCursorPosition(width, height);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(cursor);
            Console.ResetColor();
            while (true)
            {
                key = Console.ReadKey();
                Console.SetCursorPosition(width, height);

                Console.WriteLine(' ');//очистка клетки

                foreach (Trumpet pipe in pipes)
                {
                    if (height == pipe.Height && pipe.Width == width)
                    {
                        Console.SetCursorPosition(width, height);
                        pipe.Print();
                        break;
                    }
                }

                foreach (WaterSource source in sources)
                {
                    if (height == source.Height && source.Width == width)
                    {
                        Console.SetCursorPosition(width, height);
                        source.Print();
                        break;
                    }
                }
               

                if (key.Key == ConsoleKey.RightArrow)
                {
                    width++;
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    height--;
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    height++;
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    width--;
                }

                if (height == field.Height + 1)
                {
                    height--;
                }

                if (height == 0)
                {
                    height++;
                }

                if (width == field.Width + 1)
                {
                    width--;
                }

                if (width == 0)
                {
                    width++;
                }

                if (key.Key == ConsoleKey.Spacebar)
                {
                    break;
                }

                if (key.Key == ConsoleKey.Delete)
                {
                    bool didDeleted = false;

                    if (!didDeleted)
                    {
                        for (int i = 0; i < pipes.Count; i++)
                        {
                            if (pipes[i] != null)
                            {
                                if (height == pipes[i].Height && pipes[i].Width == width)
                                {
                                    pipes.RemoveAt(i);
                                    didDeleted = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!didDeleted)
                    {
                        for (int i = 0; i < sources.Count; i++)
                        {
                            if (sources[i] != null)
                            {
                                if (height == sources[i].Height && sources[i].Width == width)
                                {
                                    sources.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                    }
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    bool @is = false;

                    foreach (Trumpet pipe in pipes)
                    {
                        if (height == pipe.Height && pipe.Width == width)
                        {
                            @is = true;
                            break;
                        }
                    }

                    if (!@is)
                    {
                        for (int i = 0; i < sources.Count; i++)
                        {
                            if (sources[i] != null)
                            {
                                if (height == sources[i].Height && sources[i].Width == width)
                                {
                                    sources.RemoveAt(i);
                                    break;
                                }
                            }
                        }

                        Trumpet trumpet = new Trumpet(width, height);
                        pipes.Add(trumpet);
                    }
                    else
                    {
                        for (int i = 0; i < pipes.Count - 1; i++)
                        {
                            if (height == pipes[i].Height && pipes[i].Width == width)
                            {
                                Trumpet trumpet = new Trumpet(width, height);

                                pipes.RemoveAt(i);
                                pipes.Add(trumpet);
                                break;
                            }
                        }
                    }
                }
                else if (key.Key == ConsoleKey.S)
                {
                    bool @is = false;

                    foreach (WaterSource source in sources)
                    {
                        if (height == source.Height && source.Width == width)
                        {
                            @is = true;
                            break;
                        }
                    }

                    Console.SetCursorPosition(width, height);

                    if (!@is)
                    {
                        for (int i = 0; i < pipes.Count - 1; i++)
                        {
                            if (pipes[i] != null)
                            {
                                if (height == pipes[i].Height && pipes[i].Width == width)
                                {
                                    pipes.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        WaterSource waterSource = new WaterSource(width, height);
                        sources.Add(waterSource);
                    }
                    else
                    {
                        for (int i = 0; i < sources.Count - 1; i++)
                        {
                            if (height == sources[i].Height && sources[i].Width == width)
                            {
                                WaterSource waterSource = new WaterSource(width, height);
                                sources.RemoveAt(i);
                                waterSource.Print();
                                sources.Add(waterSource);
                                break;
                            }
                        }
                    }
                }


                Console.SetCursorPosition(width, height);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(cursor);
                Console.ResetColor();
                field.Show();
            }
        }
    } 
}