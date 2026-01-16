using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvvm.Models;
using Mvvm.Services;
using System.Collections.ObjectModel;

namespace Mvvm.PageModels
{
    public partial class GameSetupPageModel : ObservableObject
    {
        private readonly GameStateService _gameStateService;

        public GameSetupPageModel(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            _gameStateService.Players.CollectionChanged += (_, __) => StartGameCommand?.NotifyCanExecuteChanged();
        }

        [ObservableProperty]
        private string? newPlayerName;

        public bool HasGameStarted
        {
            get => _gameStateService.HasGameStarted;
            set
            {
                if (_gameStateService.HasGameStarted != value)
                {
                    _gameStateService.HasGameStarted = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Player> Players => _gameStateService.Players;

        [RelayCommand(CanExecute = nameof(CanAddPlayer))]
        private async Task AddPlayer()
        {
            if (!string.IsNullOrWhiteSpace(NewPlayerName))
            {
                Players.Add(new Player { Name = NewPlayerName, Score = 0 });
                NewPlayerName = string.Empty;
            }
        }

        [RelayCommand(CanExecute = nameof(CanStartGame))]
        private async Task StartGame()
        {
            _gameStateService.StartGame();
            OnPropertyChanged(nameof(HasGameStarted));
            await Shell.Current.GoToAsync("///scoreTracker");
        }

        private bool CanStartGame() => Players is not null && Players.Count >= 4 && Players.Count <= 10;
        private bool CanAddPlayer() => Players.Count < 10;
    }

    public partial class Player : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int score;

        [ObservableProperty]
        private bool isCorrectGuess = false;
    }
}