using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // RemoteControl er en meget simpel 'invoker' i Command pattern.
    // Man sætter en ICommand og trykker på knappen for at udføre den.
    public class RemoteControl  
    {
        private ICommand? _command;

        // Gem en kommando som skal udføres senere.
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        // Udfør den gemte kommando (hvis der er en).
        public void PressButton()
        {
            _command?.Execute();
        }

    }
}
