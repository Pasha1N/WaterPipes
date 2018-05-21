using System;
using WaterPipes.Game.MyTypes;

namespace WaterPipes.Command
{
    internal class Start : ICommand
    {
        private Bool @bool;

        public Start(Bool @bool)
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