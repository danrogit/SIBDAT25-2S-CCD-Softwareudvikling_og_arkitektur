using System;
using System.Collections.Generic;
using System.Text;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public class Light
    {
        private readonly Action<string> _statusLogger;
        public bool IsOn { get; private set; }

        public Light(Action<string>? statusLogger = null)
        {
            _statusLogger = statusLogger ?? Console.WriteLine;
        }

        public void TurnOn()
        {
            IsOn = true;
            _statusLogger("Lys er tændt.");
        }

        public void TurnOff()
        {
            IsOn = false;
            _statusLogger("Lys er slukket.");
        }
    }
}
