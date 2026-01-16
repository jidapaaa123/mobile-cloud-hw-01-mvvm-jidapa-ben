using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvvm.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Mvvm.PageModels
{
    public partial class ScoreTrackerPageModel : ObservableObject
    {
        [RelayCommand]
        private async Task EndGame()
        {
            await Shell.Current.GoToAsync("///results");
        }
    }
}
