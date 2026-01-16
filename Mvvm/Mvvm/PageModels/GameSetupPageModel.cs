using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvvm.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Mvvm.PageModels
{
    public partial class GameSetupPageModel : ObservableObject
    {
        //public event PropertyChangedEventHandler? PropertyChanged;

        [ObservableProperty]
        private string? newPlayerName;

        [ObservableProperty]
        private bool hasGameStarted;

        [ObservableProperty]
        private ObservableCollection<Player> players = new();

        //private RelayCommand addPlayerCommand;
        //public RelayCommand AddPlayerCommand => addPlayerCommand ??= new RelayCommand(() =>
        //{


        //});

        [RelayCommand]
        private async Task AddPlayer()
        {
            if (!string.IsNullOrWhiteSpace(NewPlayerName))
            {
                Players.Add(new Player { Name = NewPlayerName, Score = 0 });
                NewPlayerName = string.Empty;
            }
        }


        [RelayCommand]
        private async Task StartGame()
        {
            await Shell.Current.GoToAsync("///scoreTracker");
        }
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