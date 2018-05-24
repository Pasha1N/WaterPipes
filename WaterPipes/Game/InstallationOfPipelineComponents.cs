using System;
using System.Collections.Generic;
using WaterPipes.Command;
using WaterPipes.Game;

namespace WaterPipes.Game
{
    internal class InstallationOfPipelineComponents
    {
        private ICollection<ICommand> commands = new List<ICommand>();
        private Cursor cursor = new Cursor(1,1);
        private Field field;
        private IEnumerable<Trumpet> pipes;
        private IEnumerable<WaterSource> sources;

        public InstallationOfPipelineComponents(Field field, IEnumerable<Trumpet> pipes, IEnumerable<WaterSource> sources)
        {
            this.pipes = pipes;
            this.sources =  sources;
            this.field = field;
        }

        public void Establish()
        {
            ConsoleKeyInfo key;
            ManagementOfWork toWork = new ManagementOfWork();
            cursor.Show();
            toWork.Value = true;

            Down downArrow = new Down(cursor,field);
            Left leftArrow = new Left(cursor);
            Right rightArrow = new Right(cursor, field);
            Up upArrow = new Up(cursor);
            Start spacebar = new Start(toWork);
            Remove delete = new Remove(cursor, sources, pipes);
            AddPipe enter = new AddPipe(cursor, sources, pipes);
            AddSource s = new AddSource(cursor, sources, pipes);

            commands.Add(downArrow);
            commands.Add(leftArrow);
            commands.Add(rightArrow);
            commands.Add(upArrow);
            commands.Add(spacebar);
            commands.Add(delete);
            commands.Add(enter);
            commands.Add(s);

            while (toWork.Value)
            {
                key = Console.ReadKey();
                List<PipelineElement> pipelineElement = new List<PipelineElement>();
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