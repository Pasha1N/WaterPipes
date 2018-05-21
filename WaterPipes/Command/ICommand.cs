using System;

namespace WaterPipes.Command
{
    internal interface ICommand
    {
        void Executive(ConsoleKeyInfo key);
    }
}