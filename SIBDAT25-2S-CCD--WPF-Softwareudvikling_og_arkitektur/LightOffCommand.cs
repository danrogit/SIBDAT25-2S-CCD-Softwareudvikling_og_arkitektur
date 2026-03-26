using System;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Enkel kommando der slukker et Light-objekt.
    // Bruges i sammensatte scenarier (fx MovieMode) hvor vi skal sikre at lys slukkes.
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
