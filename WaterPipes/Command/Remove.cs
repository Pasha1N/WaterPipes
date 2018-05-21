using System;
using System.Collections.Generic;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class Remove : ICommand
    {
        private List<WaterSource> sources;
        private List<Trumpet> pipes;
        private Cursor cursor;

        public Remove(Cursor cursor, IEnumerable<WaterSource> sources, IEnumerable<Trumpet> pipes)
        {
            this.cursor = cursor;
            this.sources = (List<WaterSource>)sources;
            this.pipes = (List<Trumpet>)pipes;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Delete)
            {
                bool didDeleted = false;

                if (!didDeleted)
                {
                    for (int i = 0; i < pipes.Count; i++)
                    {
                        if (pipes[i] != null)
                        {
                            if (cursor.Y == pipes[i].Height && pipes[i].Width == cursor.X)
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
                            if (cursor.Y == sources[i].Height && sources[i].Width == cursor.X)
                            {
                                sources.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}