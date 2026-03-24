using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SIBDAT_25_CCD_Softwareudvikling_og_arkitektur;

namespace SIBDAT25_2S_CCD__WPF_Softwareudvikling_og_arkitektur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IHomeStateObserver
    {
        private readonly Client _client;
        private readonly Light _light;
        private readonly Thermostat _thermostat;
        private readonly ICommand _movieModeCommand;
        private readonly HomeStateSubject _homeStateSubject;
        private bool _isLightEnabled;
        private bool _isMovieModeEnabled;

        public MainWindow()
        {
            InitializeComponent();
            RemoteControl remoteControl = new RemoteControl();
            _light = new Light(AddStatus);
            _thermostat = new Thermostat(AddStatus);
            _client = new Client(remoteControl, new[] { _light }, _thermostat);

            _movieModeCommand = new MovieModeCommand(new List<ICommand>
            {
                new MovieModeAdapter(new LegacyTvSystem(AddStatus)),
                new LightOffCommand(_light),
                new SetTemperaturCommand(20, _thermostat)
            });

            _homeStateSubject = new HomeStateSubject();
            _homeStateSubject.Subscribe(this);
            UpdateLightIconState();
            UpdateMovieIconState();
            AddStatus("System klar.");
        }

        private void ToggleLight_Click(object sender, RoutedEventArgs e)
        {
            _client.Control(new ToggleLightCommand(_light));
            _homeStateSubject.Notify(new HomeStateChangedEvent(HomeStateType.Light, isEnabled: _light.IsOn));
        }

        private void MovieMode_Click(object sender, RoutedEventArgs e)
        {
            if (_isMovieModeEnabled)
            {
                _movieModeCommand.TurnOff();
                _homeStateSubject.Notify(new HomeStateChangedEvent(HomeStateType.Light, isEnabled: _light.IsOn));
                _homeStateSubject.Notify(new HomeStateChangedEvent(HomeStateType.Temperature, temperature: _thermostat.Temperature));
                _homeStateSubject.Notify(new HomeStateChangedEvent(HomeStateType.MovieMode, isEnabled: false));
                return;
            }

            _client.Activate(_movieModeCommand);
            _homeStateSubject.Notify(new HomeStateChangedEvent(HomeStateType.Light, isEnabled: _light.IsOn));
            _homeStateSubject.Notify(new HomeStateChangedEvent(HomeStateType.Temperature, temperature: _thermostat.Temperature));
            _homeStateSubject.Notify(new HomeStateChangedEvent(HomeStateType.MovieMode, isEnabled: true));
        }

        private void SetTemperature_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(TemperatureInput.Text, out int value))
            {
                AddStatus("Ugyldig temperatur. Indtast et tal.");
                return;
            }

            if (value < 0 || value > 30)
            {
                AddStatus("Temperatur skal være mellem 0 og 30.");
                return;
            }

            _client.Control(new SetTemperaturCommand(value, _thermostat));
            _homeStateSubject.Notify(new HomeStateChangedEvent(HomeStateType.Temperature, temperature: value));
        }

        public void OnHomeStateChanged(HomeStateChangedEvent homeState)
        {
            switch (homeState.Type)
            {
                case HomeStateType.Light:
                    _isLightEnabled = homeState.IsEnabled ?? false;
                    UpdateLightIconState();
                    break;
                case HomeStateType.MovieMode:
                    _isMovieModeEnabled = homeState.IsEnabled ?? false;
                    SetMovieModeButtonText(_isMovieModeEnabled ? "Filmtilstand: Til" : "Filmtilstand: Fra");
                    UpdateMovieIconState();
                    break;
                case HomeStateType.Temperature:
                    if (homeState.Temperature.HasValue)
                    {
                        UpdateTemperatureDisplay(homeState.Temperature.Value);
                    }
                    break;
            }
        }

        private void AddStatus(string message)
        {
            StatusList.Items.Insert(0, message);
        }

        private void UpdateTemperatureDisplay(int temperature)
        {
            TextBlock? currentTemperatureText = FindName("CurrentTemperatureText") as TextBlock;
            if (currentTemperatureText is null)
            {
                return;
            }

            currentTemperatureText.Text = $"{temperature} °C";

            if (temperature <= 12)
            {
                currentTemperatureText.Foreground = Brushes.Blue;
                return;
            }

            if (temperature <= 22)
            {
                // Use same orange as the light icon for the mid temperature range
                currentTemperatureText.Foreground = Brushes.Orange;
                return;
            }

            currentTemperatureText.Foreground = Brushes.Red;
        }

        private void SetMovieModeButtonText(string text)
        {
            Button? movieModeButton = FindName("MovieModeButton") as Button;
            if (movieModeButton is null)
            {
                return;
            }

            movieModeButton.Content = text;
        }

        private void UpdateLightIconState()
        {
            TextBlock? lightIcon = FindName("LightIcon") as TextBlock;
            if (lightIcon is null)
            {
                return;
            }

            lightIcon.Foreground = _isLightEnabled ? Brushes.Orange : Brushes.Gray;
        }

        private void UpdateMovieIconState()
        {
            TextBlock? movieIcon = FindName("MovieIcon") as TextBlock;
            if (movieIcon is null)
            {
                return;
            }

            movieIcon.Foreground = _isMovieModeEnabled ? Brushes.Blue : Brushes.Gray;
        }
    }
}