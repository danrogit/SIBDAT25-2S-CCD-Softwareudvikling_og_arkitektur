using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public class MovieModeCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        public MovieModeCommand(List<ICommand> commands)
        {
            _commands = commands;
        }

        public void Execute()
        {
            foreach (ICommand command in _commands)
            {
                command.Execute();
            }
        }

        public void TurnOn()
        {
            Execute();
        }

        public void TurnOff()
        {
            foreach (ICommand command in _commands)
            {
                command.TurnOff();
            }
        }
    }
}
