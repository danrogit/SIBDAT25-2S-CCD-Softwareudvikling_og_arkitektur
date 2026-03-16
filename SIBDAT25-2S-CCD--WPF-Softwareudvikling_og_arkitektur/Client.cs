using System;
using System.Collections.Generic;
using System.Linq;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public class Client
    {
        private readonly RemoteControl _remoteControl;
        private readonly List<Light> _lights;

        public Client(RemoteControl remoteControl, IEnumerable<Light> lights, Thermostat thermostat)
        {
            _remoteControl = remoteControl;
            _lights = lights.ToList();
            Thermostat = thermostat;
        }

        public IReadOnlyList<Light> Lights => _lights;
        public Thermostat Thermostat { get; }

        public void Control(ICommand command)
        {
            _remoteControl.SetCommand(command);
            _remoteControl.PressButton();
        }

        public void Activate(ICommand command)
        {
            Control(command);
        }
    }
}
