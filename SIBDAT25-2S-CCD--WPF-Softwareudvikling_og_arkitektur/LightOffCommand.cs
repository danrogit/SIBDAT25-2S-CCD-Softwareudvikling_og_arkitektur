using System;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public class LightOffCommand : ICommand
    {
        private readonly Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
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
