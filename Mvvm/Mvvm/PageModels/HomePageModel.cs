using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvvm.PageModels
{
    public partial class HomePageModel : ObservableObject
    {
        [RelayCommand]
        public async Task NewGame()
        {
            await Shell.Current.GoToAsync("///gameSetup");
        }
    }
}
