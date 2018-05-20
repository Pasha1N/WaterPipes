using System;
using System.Collections.Generic;
using WaterPipes.Command;
using WaterPipes.Game.MyTypes;

namespace WaterPipes.Game
{
    internal class InstallationOfPipelineComponents
    {
        private List<ICommand> commands = new List<ICommand>();
        private Cursor cursor = new Cursor(1,1);
        private Field field;
        private List<Trumpet> pipes;
        private List<PipelineElement> pipelineElement = new List<PipelineElement>();
        private List<WaterSource> sources;

        public InstallationOfPipelineComponents(Field field, IEnumerable<Trumpet> pipes, IEnumerable<WaterSource> sources)
        {
            this.pipes = (List<Trumpet>)pipes;
            this.sources = (List<WaterSource>) sources;
            this.field = field;
        }

        public void Establish()
        {
            ConsoleKeyInfo key;
            Bool work = new Bool();
            cursor.Show();
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
                pipelineElement.AddRange(pipes);
                pipelineElement.AddRange(sources);

                Console.SetCursorPosition(cursor.X, cursor.Y);
                // очистка хвоста
                Console.WriteLine(' ');

                foreach (PipelineElement element in pipelineElement)
                {
                    if (cursor.Y == element.Height && element.Width == cursor.X)
                    {
                        Console.SetCursorPosition(cursor.X, cursor.Y);
                        element.Print();
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