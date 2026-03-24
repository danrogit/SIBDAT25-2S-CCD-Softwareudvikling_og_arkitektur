using System;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public class ToggleLightCommand : ICommand
    {
        private readonly Light _light;

        public ToggleLightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            Toggle();
        }

        public void Toggle()
        {
            _light.Toggle();
        }

        public void TurnOn()
        {
            _light.TurnOn();
        }

        public void TurnOff()
        {
            _light.TurnOff();
        }
    }
}
