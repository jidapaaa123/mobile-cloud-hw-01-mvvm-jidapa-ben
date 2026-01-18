using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvvm.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvvm.PageModels
{
    public partial class HomePageModel : ObservableObject
    {
        private readonly GameStateService _gameStateService;

        public HomePageModel(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        [RelayCommand]
        public async Task NewGame()
        {
            // Reset all game state including clearing all players
            _gameStateService.ResetGame();
            
            await Shell.Current.GoToAsync("///gameSetup");
        }
    }
}
