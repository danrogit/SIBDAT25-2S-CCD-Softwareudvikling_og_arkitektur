using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Kommando der sætter temperaturen via Thermostat.
    // Viser også en simpel kalibreringsmetode til at sikre gyldigt interval.
    public class SetTemperaturCommand : ICommand
    {
        private readonly Thermostat _thermostat;
        private readonly int _field;

        public SetTemperaturCommand(int temperatur, Thermostat thermostat)
        {
            _field = temperatur;
            _thermostat = thermostat;
        }

        // Execute anvender kalibreret værdi på Thermostat.
        public void Execute()
        {
            _thermostat.SetTemperature(Calibrate(_field));
        }

        // Simpel kalibrering: begræns temperatur til intervallet [0,30].
        public int Calibrate(int temperatur)
        {
            if (temperatur < 0)
            {
                return 0;
            }

            if (temperatur > 30)
            {
                return 30;
            }

            return temperatur;
        }

        public void TurnOn()
        {
            Execute();
        }

        public void TurnOff()
        {
            // Ingen handling ved TurnOff for temperaturkommando.
        }

    }
    
}
