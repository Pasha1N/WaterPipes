using System;
using System.Collections.Generic;
using WaterPipes.Command;
using WaterPipes.Game.MyTypes;

namespace WaterPipes.Game
{
    internal class InstallationOfPipelineComponents
    {
        private Cursor cursor = new Cursor(1,1);
        private Field field;
        private List<Trumpet> pipes;
        private List<WaterSource> sources;
        private List<ICommand> commands = new List<ICommand>();

        public InstallationOfPipelineComponents(Field field, IEnumerable<Trumpet> pipes, List<WaterSource> sources)
        {
            this.pipes = (List<Trumpet>)pipes;
            this.sources = sources;
            this.field = field;
        }

        public void Establish()
        {
            ConsoleKeyInfo key;
            cursor.Show();
            Bool work = new Bool();
            work.Value = true;

            DownArrow downArrow = new DownArrow(cursor,field);
            LeftArrow leftArrow = new LeftArrow(cursor);
            RightArrow rightArrow = new RightArrow(cursor, field);
            UpArrow upArrow = new UpArrow(cursor);
            Spacebar spacebar = new Spacebar(work);
            Delete delete = new Delete(cursor, sources, pipes);
            Enter enter = new Enter(cursor, sources, pipes);
            S s = new S(cursor, sources, pipes);

            commands.Add(downArrow);
            commands.Add(leftArrow);
            commands.Add(rightArrow);
            commands.Add(upArrow);
            commands.Add(spacebar);
            commands.Add(delete);
            commands.Add(enter);
            commands.Add(s);

            while (work.Value)
            {
                key = Console.ReadKey();
                Console.SetCursorPosition(cursor.X, cursor.Y);

                //очистка хвоста
                Console.WriteLine(' ');

                foreach (Trumpet pipe in pipes)
                {
                    if (cursor.Y == pipe.Height && pipe.Width == cursor.X )
                    {
                        Console.SetCursorPosition(cursor.X, cursor.Y);
                        pipe.Print();
                        break;
                    }
                }

                foreach (WaterSource source in sources)
                {
                    if (cursor.Y == source.Height && source.Width == cursor.X)
                    {
                        Console.SetCursorPosition(cursor.X, cursor.Y);
                        source.Print();
                        break;
                    }
                }

                foreach (ICommand command in commands)
                {
                    command.Executive(key);
                }

                Console.ResetColor();
                cursor.Show();              
                field.Show();
            }
        }
    } 
}