using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public class RemoteControl  
    {
        private ICommand? _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            _command?.Execute();
        }

    }
}
