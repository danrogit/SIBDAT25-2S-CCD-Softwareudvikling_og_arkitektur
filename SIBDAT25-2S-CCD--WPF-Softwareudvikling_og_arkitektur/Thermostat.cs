using System;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Enkel Thermostat-domæneklasse.
    // Ansvar: Gemme og sætte aktuel temperatur.
    public class Thermostat
    {
        private readonly Action<string> _statusLogger;
        public int Temperature { get; private set; }

        public Thermostat(Action<string>? statusLogger = null)
        {
            _statusLogger = statusLogger ?? Console.WriteLine;
        }

        // Sæt temperatur og log handlingen.
        public void SetTemperature(int temperature)
        {
            Temperature = temperature;
            _statusLogger($"Temperatur sat til {Temperature}°C.");
        }
    }
}
