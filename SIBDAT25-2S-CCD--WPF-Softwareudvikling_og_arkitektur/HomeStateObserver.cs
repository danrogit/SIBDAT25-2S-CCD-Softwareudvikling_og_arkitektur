using System;
using System.Collections.Generic;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    public enum HomeStateType
    {
        Light,
        MovieMode,
        Temperature
    }

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

    public interface IHomeStateObserver
    {
        void OnHomeStateChanged(HomeStateChangedEvent homeState);
    }

    public class HomeStateSubject
    {
        private readonly List<IHomeStateObserver> _observers = new List<IHomeStateObserver>();

        public void Subscribe(IHomeStateObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Unsubscribe(IHomeStateObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(HomeStateChangedEvent homeState)
        {
            foreach (IHomeStateObserver observer in _observers)
            {
                observer.OnHomeStateChanged(homeState);
            }
        }
    }
}
