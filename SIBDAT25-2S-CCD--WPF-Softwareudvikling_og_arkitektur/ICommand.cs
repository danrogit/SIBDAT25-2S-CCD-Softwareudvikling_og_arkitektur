using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Enkel kommando-interface for Command pattern.
    // Hver implementering repræsenterer en handling der kan udføres på en enhed.
    public interface ICommand
    {
        public void Execute();

        public void TurnOn();
        public void TurnOff();
    }
}
