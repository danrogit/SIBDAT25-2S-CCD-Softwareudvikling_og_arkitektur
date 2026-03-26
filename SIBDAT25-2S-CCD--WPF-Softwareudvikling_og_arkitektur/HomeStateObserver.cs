using System;
using System.Collections.Generic;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Observer pattern: Event-objekt og subject til at notificere UI når state ændres.
    public enum HomeStateType
    {
        Light,
        MovieMode,
        Temperature
    }

    // En simpel event-holder der indeholder info om hvilken type state der ændredes.
    public sealed class HomeStateChangedEvent
    {
        public HomeStateType Type { get; }
        public bool? IsEnabled { get; }
        public int? Temperature { get; }

        public HomeStateChangedEvent(HomeStateType type, bool? isEnabled = null, int? temperature = null)
        {
            Type = type;
            IsEnabled = isEnabled;
            Temperature = temperature;
        }
    }

    // Interface for observatører (fx UI) som ønsker at modtage state-opdateringer.
    public interface IHomeStateObserver
    {
        void OnHomeStateChanged(HomeStateChangedEvent homeState);
    }

    // Subject holder en liste af observers og notifies dem ved ændringer.
    public class HomeStateSubject
    {
        private readonly List<IHomeStateObserver> _observers = new List<IHomeStateObserver>();

        // Tilmeld en observer.
        public void Subscribe(IHomeStateObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        // Frameld en observer.
        public void Unsubscribe(IHomeStateObserver observer)
        {
            _observers.Remove(observer);
        }

        // Underret alle observers om en state-ændring.
        public void Notify(HomeStateChangedEvent homeState)
        {
            foreach (IHomeStateObserver observer in _observers)
            {
                observer.OnHomeStateChanged(homeState);
            }
        }
    }
}
