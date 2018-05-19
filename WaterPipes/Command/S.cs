using System;
using System.Collections.Generic;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class S : ICommand
    {
        private List<WaterSource> sources;
        private List<Trumpet> pipes;
        private Cursor cursor;

        public S(Cursor cursor, IEnumerable<WaterSource> sources, IEnumerable<Trumpet> pipes)
        {
            this.cursor = cursor;
            this.sources = (List<WaterSource>)sources;
            this.pipes = (List<Trumpet>)pipes;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.S)
            {
                bool @is = false;

                foreach (WaterSource source in sources)
                {
                    if (cursor.Y == source.Height && source.Width == cursor.X)
                    {
                        @is = true;
                        break;
                    }
                }

                Console.SetCursorPosition(cursor.X, cursor.Y);

                if (!@is)
                {
                    for (int i = 0; i < pipes.Count - 1; i++)
                    {
                        if (pipes[i] != null)
                        {
                            if (cursor.Y == pipes[i].Height && pipes[i].Width == cursor.X)
                            {
                                pipes.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    WaterSource waterSource = new WaterSource(cursor.X, cursor.Y);
                    sources.Add(waterSource);
                }
                else
                {
                    for (int i = 0; i < sources.Count - 1; i++)
                    {
                        if (cursor.Y == sources[i].Height && sources[i].Width == cursor.X)
                        {
                            WaterSource waterSource = new WaterSource(cursor.X, cursor.Y);
                            sources.RemoveAt(i);
                            waterSource.Print();
                            sources.Add(waterSource);
                            break;
                        }
                    }
                }
            }
        }
    }
}