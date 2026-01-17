using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvvm.PageModels
{
    public partial class ResultsPageModel : ObservableObject
    {

        private readonly GameStateService gameStateService;

        [ObservableProperty]
        private string resultsString = string.Empty;
        [ObservableProperty]
        private int highestScore;

        public ResultsPageModel(GameStateService gameStateService)
        {
            this.gameStateService = gameStateService;
            HighestScore = gameStateService.Players
                    .OrderByDescending(p => p.Score)
                    .FirstOrDefault()
                    ?.Score ?? 0;
            var winners = gameStateService.Players
                    .Where(p => p.Score == HighestScore)
                    .Select(p => p.Name)
                    .ToList();
            ResultsString = $"{string.Join(" and ", winners)} with" +
                $" {HighestScore} points!";
        }

    }
}
