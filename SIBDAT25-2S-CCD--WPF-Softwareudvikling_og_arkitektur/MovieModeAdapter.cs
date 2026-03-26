using System;

namespace SIBDAT_25_CCD_Softwareudvikling_og_arkitektur
{
    // Adapter pattern: oversætter ILegacyTvSystem til ICommand interface.
    public interface ILegacyTvSystem
    {
        void EnableCinemaMode();
        void DisableCinemaMode();
    }

    public class LegacyTvSystem : ILegacyTvSystem
    {
        private readonly Action<string> _statusLogger;

        public LegacyTvSystem(Action<string>? statusLogger = null)
        {
            _statusLogger = statusLogger ?? Console.WriteLine;
        }

        public void EnableCinemaMode()
        {
            _statusLogger("TV er sat i filmtilstand.");
        }

        public void DisableCinemaMode()
        {
            _statusLogger("TV er tilbage i normal tilstand.");
        }
    }

    public class MovieModeAdapter : ICommand
    {
        private readonly ILegacyTvSystem _legacyTvSystem;

        public MovieModeAdapter(ILegacyTvSystem legacyTvSystem)
        {
            _legacyTvSystem = legacyTvSystem;
        }

        public void Execute()
        {
            TurnOn();
        }

        public void TurnOn()
        {
            _legacyTvSystem.EnableCinemaMode();
        }

        public void TurnOff()
        {
            _legacyTvSystem.DisableCinemaMode();
        }
    }
}
