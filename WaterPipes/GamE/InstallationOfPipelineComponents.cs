﻿using System;

namespace WaterPipes.GamE
{
    class InstallationOfPipelineComponents
    {
        private int height = 1;
        private int width = 1;
        private Field field;
        private ArrayOfPipes objectOfPipes = null;
        private ArrayOfSources objectOfSources = null;
        private WaterSource[] Sources = null;
        private Trumpet[] Pipes = null;

        public InstallationOfPipelineComponents(Field field, ArrayOfPipes objectOfPipes, ArrayOfSources objectOfSources)
        {
            this.objectOfSources = objectOfSources;
            this.objectOfPipes = objectOfPipes;
            this.field = field;
        }

        public void Establish()
        {
            ConsoleKeyInfo key;
            while (true)
            {
                Pipes = objectOfPipes.GetPipes();
                Sources = objectOfSources.GetSources();

                key = Console.ReadKey();
                Console.SetCursorPosition(width, height);

                if (true)
                {
                    Console.WriteLine(' ');
                }

                for (int i = 0; i < Pipes.Length; i++)
                {
                    if (Pipes[i] != null)
                    {
                        if (Pipes[i].GetWidth() == width && Pipes[i].GetHeight() == height)
                        {
                            Console.SetCursorPosition(width, height);
                            Pipes[i].Print();
                            break;
                        }
                    }
                    else { break; }
                }

                for (int i = 0; i < Sources.Length; i++)
                {
                    if (Sources[i] != null)
                    {
                        if (Sources[i].GetWidth() == width && Sources[i].GetHeight() == height)
                        {
                            Console.SetCursorPosition(width, height);
                            Sources[i].Print();
                            break;
                        }
                    }
                    else { break; }
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

                if (height == field.Getheight() + 1)
                {
                    height--;
                }

                if (height == 0)
                {
                    height++;
                }

                if (width == field.GetWidth() + 1)
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

                    if (didDeleted == false)
                    {
                        for (int i = 0; i < Pipes.Length; i++)
                        {
                            if (Pipes[i] != null)
                            {
                                if (height == Pipes[i].GetHeight() && Pipes[i].GetWidth() == width)
                                {
                                    Array.Clear(Pipes, i, 1);
                                    int Index = Array.IndexOf(Pipes, null);

                                    for (int j = Index; j < Pipes.Length - 1; j++)
                                    {
                                        Pipes[j] = Pipes[j + 1];
                                    }

                                    didDeleted = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (didDeleted == false)
                    {
                        for (int i = 0; i < Sources.Length; i++)
                        {
                            if (Sources[i] != null)
                            {
                                if (height == Sources[i].GetHeight() && Sources[i].GetWidth() == width)
                                {
                                    Array.Clear(Sources, i, 1);
                                    int Index = Array.IndexOf(Sources, null);

                                    for (int j = Index; j < Sources.Length - 1; j++)
                                    {
                                        Sources[j] = Sources[j + 1];
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    bool Is = false;
                    for (int i = 0; i < Pipes.Length; i++)
                    {
                        if (Pipes[i] != null)
                        {
                            if (height == Pipes[i].GetHeight() && Pipes[i].GetWidth() == width)
                            {
                                Is = true;
                                break;
                            }
                        }
                    }

                    if (!Is)
                    {
                        for (int i = 0; i < Sources.Length; i++)//
                        {
                            if (Sources[i] != null)
                            {
                                if (height == Sources[i].GetHeight() && Sources[i].GetWidth() == width)
                                {
                                    Array.Clear(Sources, i, 1);
                                    int Index = Array.IndexOf(Sources, null);
                                    for (int j = Index; j < Sources.Length - 1; j++)
                                    {
                                        Sources[j] = Sources[j + 1];
                                    }
                                    break;
                                }
                            }
                        }

                        Trumpet trumpet = new Trumpet(width, height);
                        objectOfPipes.AddTrumpet(trumpet);
                    }
                    else
                    {
                        for (int i = 0; i < Pipes.Length - 1; i++)
                        {
                            if (height == Pipes[i].GetHeight() && Pipes[i].GetWidth() == width)
                            {
                                Trumpet trumpet = new Trumpet(width, height);
                                Array.Clear(Pipes, i, 1);
                                objectOfPipes.AddTrumpet(trumpet);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.S)
                    {
                        bool Is = false;
                        for (int i = 0; i < Sources.Length; i++)
                        {
                            if (Sources[i] != null)
                            {
                                if (height == Sources[i].GetHeight() && Sources[i].GetWidth() == width)
                                {
                                    Is = true;
                                    break;
                                }
                            }
                        }

                        if (!Is)
                        {
                            for (int i = 0; i < Pipes.Length - 1; i++)
                            {
                                if (Pipes[i] != null)
                                {
                                    if (height == Pipes[i].GetHeight() && Pipes[i].GetWidth() == width)
                                    {
                                        Array.Clear(Pipes, i, 1);
                                        int Index = Array.IndexOf(Pipes, null);

                                        for (int j = Index; j < Pipes.Length - 1; j++)
                                        {
                                            Pipes[j] = Pipes[j + 1];
                                        }
                                        break;
                                    }
                                }
                            }
                            WaterSource waterSource = new WaterSource(width, height);
                            objectOfSources.AddSource(waterSource);
                            waterSource.Print();
                        }
                        else
                        {
                            for (int i = 0; i < Sources.Length - 1; i++)
                            {
                                if (height == Sources[i].GetHeight() && Sources[i].GetWidth() == width)
                                {
                                    WaterSource waterSource = new WaterSource(width, height);
                                    Array.Clear(Sources, i, 1);
                                    objectOfSources.AddSource(waterSource);
                                    waterSource.Print();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(width, height);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine('X');
                        Console.ResetColor();
                        field.Show();
                    }
                }
            }
        }
    }
}