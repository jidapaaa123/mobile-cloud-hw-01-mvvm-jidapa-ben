using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvvm.Models;
using Mvvm.Services;
using System.Collections.ObjectModel;

namespace Mvvm.PageModels
{
    public partial class ScoreTrackerPageModel : ObservableObject
    {
        private readonly GameStateService _gameStateService;

        public ScoreTrackerPageModel(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            
            // Initialize local properties from service
            currentRound = _gameStateService.CurrentRound;
            currentPlayerIndex = _gameStateService.CurrentPlayerIndex;
        }

        public ObservableCollection<Player> Players => _gameStateService.Players;

        public bool HasGameStarted => _gameStateService.HasGameStarted;

        [ObservableProperty]
        private int currentRound;

        [ObservableProperty]
        private int currentPlayerIndex;

        public Player? CurrentPlayer => Players.Count > 0 && CurrentPlayerIndex < Players.Count 
            ? Players[CurrentPlayerIndex] 
            : null;

        public ObservableCollection<Player> OtherPlayers
        {
            get
            {
                var others = new ObservableCollection<Player>();
                for (int i = 0; i < Players.Count; i++)
                {
                    if (i != CurrentPlayerIndex)
                    {
                        others.Add(Players[i]);
                    }
                }
                return others;
            }
        }

        [RelayCommand]
        private void NextRound()
        {
            if (CurrentPlayer == null) return;

            // Calculate scores based on the guessing logic
            CalculateScores();

            // Reset correct guess flags for next round
            foreach (var player in Players)
            {
                player.IsCorrectGuess = false;
            }

            // Move to next round in service
            _gameStateService.NextRound();

            // Sync local properties with service - this triggers OnPropertyChanged automatically
            CurrentRound = _gameStateService.CurrentRound;
            CurrentPlayerIndex = _gameStateService.CurrentPlayerIndex;

            // Notify UI of dependent properties
            OnPropertyChanged(nameof(CurrentPlayer));
            OnPropertyChanged(nameof(OtherPlayers));
        }

        private void CalculateScores()
        {
            if (CurrentPlayer == null) return;

            int correctGuesses = 0;

            // Score guessers
            foreach (var player in OtherPlayers)
            {
                if (player.IsCorrectGuess)
                {
                    // Guesser earns 3 points for correct guess
                    player.Score += 3;
                    correctGuesses++;
                }
                // Otherwise they earn 0 points (no change needed)
            }

            // Score current player: 1 point for each correct guess
            CurrentPlayer.Score += correctGuesses;
        }

        [RelayCommand]
        private async Task EndGame()
        {
            _gameStateService.EndGame();
            await Shell.Current.GoToAsync("///results");
        }
    }
}
