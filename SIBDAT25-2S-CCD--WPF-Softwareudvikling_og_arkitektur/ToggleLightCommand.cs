using System;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Simple command for at skifte et lys: tænd hvis slukket, sluk hvis tændt.
    public class ToggleLightCommand : ICommand
    {
        private readonly Light _light;

        public ToggleLightCommand(Light light)
        {
            _light = light;
        }

        // Når kommandoen udføres, toggles lysets state.
        public void Execute()
        {
            Toggle();
        }

        public void Toggle()
        {
            _light.Toggle();
        }

        // Aux-metoder der følger ICommand contract.
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
