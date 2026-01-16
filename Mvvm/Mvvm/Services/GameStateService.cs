using System.Collections.ObjectModel;
using Mvvm.Models;

namespace Mvvm.Services
{
    public class GameStateService
    {
        public ObservableCollection<Player> Players { get; set; } = new();
        public bool HasGameStarted { get; set; }
        public int CurrentRound { get; set; } = 1;
        public int CurrentPlayerIndex { get; set; } = 0;

        public void ResetGame()
        {
            Players.Clear();
            HasGameStarted = false;
            CurrentRound = 1;
            CurrentPlayerIndex = 0;
        }

        public void StartGame()
        {
            HasGameStarted = true;
            CurrentRound = 1;
            CurrentPlayerIndex = 0;
        }

        public void EndGame()
        {
            HasGameStarted = false;
        }

        public void NextRound()
        {
            CurrentPlayerIndex++;

            if (CurrentPlayerIndex >= Players.Count)
            {
                CurrentPlayerIndex = 0;
            }
            CurrentRound++;
        }
    }
}
