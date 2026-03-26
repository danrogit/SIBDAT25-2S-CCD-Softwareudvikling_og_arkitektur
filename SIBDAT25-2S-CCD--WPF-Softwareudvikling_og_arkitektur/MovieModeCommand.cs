using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // MovieModeCommand er en sammensat kommando, som kører flere commands.
    // Bruges til at aktivere et scenarie (fx filmtilstand) der påvirker flere enheder.
    public class MovieModeCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        // Modtag en liste af ICommand som skal udføres når MovieMode aktiveres.
        public MovieModeCommand(List<ICommand> commands)
        {
            _commands = commands;
        }

        // Udfør alle indlejrede kommandoer.
        public void Execute()
        {
            foreach (ICommand command in _commands)
            {
                command.Execute();
            }
        }

        // TurnOn/TurnOff kalder Execute eller slukker alle kommandoer.
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
