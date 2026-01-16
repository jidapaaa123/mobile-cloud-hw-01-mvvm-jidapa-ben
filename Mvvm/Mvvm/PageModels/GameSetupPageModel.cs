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

        //[ObservableProperty]
        //private string? newPlayerName;

        //[ObservableProperty]
        //private bool hasGameStarted;

        //[ObservableProperty]
        //private ObservableCollection<Player> Players;

        //private RelayCommand addPlayerCommand;
        //public RelayCommand AddPlayerCommand => addPlayerCommand ??= new RelayCommand(() =>
        //{


        //});

        //private RelayCommand startGameCommand;
        //public RelayCommand StartGameCommand => startGameCommand ??= new RelayCommand(() =>
        //{


        //});

        [RelayCommand]
        private async Task StartGame()
        {
            await Shell.Current.GoToAsync("///scoreTracker");
        }
    }



    public partial class Player : ObservableObject
    {
        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public int score;

        [ObservableProperty]
        public bool isCorrectGuess = false;

    }

}