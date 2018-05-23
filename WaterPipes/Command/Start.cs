using System;
using WaterPipes.Game;

namespace WaterPipes.Command
{
    internal class Start : ICommand
    {
        private ManagementOfWork @bool;

        public Start(ManagementOfWork @bool)
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