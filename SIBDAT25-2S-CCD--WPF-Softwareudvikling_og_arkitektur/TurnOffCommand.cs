using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public class TurnOffCommand : ICommand
    {
        private readonly Light _light;

        public TurnOffCommand(Light light)
        {
            _light = light;
        }

        public void TurnOff()
        {
            _light.TurnOff();
        }

        public void TurnOn() 
        {
            _light.TurnOn();
        }

        public void Execute()
        {
            TurnOff();
        }

    }
}
