using System;
using WaterPipes.Game.MyTypes;

namespace WaterPipes.Command
{
    internal class Spacebar : ICommand
    {
        private Bool @bool;

        public Spacebar(Bool @bool)
        {
            this.@bool = @bool;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Spacebar)
            {
                @bool.Value = false;
            }
        }
    }
}