using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Domæneklasse for en lyskilde i hjemmet.
    // Indeholder simpel state (IsOn) og metoder til at tænde/slukke.
    public class Light
    {
        private readonly Action<string> _statusLogger;
        public bool IsOn { get; private set; }

        // Konstruktor tager en logger-callback, så vi kan vise beskeder i UI.
        public Light(Action<string>? statusLogger = null)
        {
            _statusLogger = statusLogger ?? Console.WriteLine;
        }

        // Tænd lyset og log handlingen.
        public void TurnOn()
        {
            IsOn = true;
            _statusLogger("Lys er tændt.");
        }

        // Sluk lyset og log handlingen.
        public void TurnOff()
        {
            IsOn = false;
            _statusLogger("Lys er slukket.");
        }

        // Hjælpemetode der skifter state (bruges af toggle-knap).
        public void Toggle()
        {
            if (IsOn)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }
    }
}
