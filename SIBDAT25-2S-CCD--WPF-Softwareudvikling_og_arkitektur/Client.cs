using System;
using System.Collections.Generic;
using System.Linq;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Client repræsenterer en bruger eller controller der aktiverer commands.
    // Den bruger RemoteControl til at sende kommandoer til enheder.
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

        // Liste over tilknyttede lys.
        public IReadOnlyList<Light> Lights => _lights;
        public Thermostat Thermostat { get; }

        // Sætter en kommando i remote control og udfører den.
        public void Control(ICommand command)
        {
            _remoteControl.SetCommand(command);
            _remoteControl.PressButton();
        }

        // Aktivér en kommando (alias til Control).
        public void Activate(ICommand command)
        {
            Control(command);
        }
    }
}
