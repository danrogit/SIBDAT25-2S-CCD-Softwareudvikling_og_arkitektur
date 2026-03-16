using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public interface ICommand
    {
        public void Execute();

        public void TurnOn();
        public void TurnOff();
    }
}
