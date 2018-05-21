using System;
using System.Collections.Generic;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class AddPipe : ICommand
    {
        private List<WaterSource> sources;
        private List<Trumpet> pipes;
        private Cursor cursor;

        public AddPipe(Cursor cursor, IEnumerable<WaterSource> sources, IEnumerable<Trumpet> pipes)
        {
            this.cursor = cursor;
            this.sources = (List<WaterSource>)sources;
            this.pipes = (List<Trumpet>)pipes;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
            {
                bool @is = false;

                foreach (Trumpet pipe in pipes)
                {
                    if (cursor.Y == pipe.Height && pipe.Width == cursor.X)
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
                            if (cursor.Y == sources[i].Height && sources[i].Width == cursor.X)
                            {
                                sources.RemoveAt(i);
                                break;
                            }
                        }
                    }

                    Trumpet trumpet = new Trumpet(cursor.X, cursor.Y);
                    pipes.Add(trumpet);
                }
                else
                {
                    for (int i = 0; i < pipes.Count - 1; i++)
                    {
                        if (cursor.Y == pipes[i].Height && pipes[i].Width == cursor.X)
                        {
                            Trumpet trumpet = new Trumpet(cursor.X, cursor.Y);

                            pipes.RemoveAt(i);
                            pipes.Add(trumpet);
                            break;
                        }
                    }
                }
            }
        }
    }
}