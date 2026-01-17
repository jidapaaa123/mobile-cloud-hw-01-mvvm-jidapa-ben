using Xunit;
using Mvvm.PageModels;
using Mvvm.Services;

namespace Mvvm.Tests
{
    public class ScoreTrackerPageModelTests
    {
        [Fact]
        public void NextRound_CalculatesScoresAndAdvancesState()
        {
            var svc = new GameStateService();
            svc.Players.Add(new Player { Name = "Current", Score = 0 });
            svc.Players.Add(new Player { Name = "G1", Score = 0, IsCorrectGuess = true });  
            svc.Players.Add(new Player { Name = "G2", Score = 0, IsCorrectGuess = false });
            svc.Players.Add(new Player { Name = "G3", Score = 0, IsCorrectGuess = false });
            svc.StartGame();

            var vm = new ScoreTrackerPageModel(svc);

            // preconditions
            Assert.Equal(1, svc.CurrentRound);
            Assert.Equal(0, svc.CurrentPlayerIndex);
            Assert.Equal(0, svc.Players[0].Score);
            Assert.Equal(0, svc.Players[1].Score);
            Assert.Equal(0, svc.Players[2].Score);
            Assert.Equal(0, svc.Players[3].Score);


            // execute generated command
            vm.NextRoundCommand.Execute(null);

            // G1 earned +3, current player earned +1 (one correct guess)
            Assert.Equal(1, svc.Players[0].Score);
            Assert.Equal(3, svc.Players[1].Score);
            Assert.Equal(0, svc.Players[2].Score);
            Assert.Equal(0, svc.Players[3].Score);

            // IsCorrectGuess flags are reset
            Assert.False(svc.Players[0].IsCorrectGuess);
            Assert.False(svc.Players[1].IsCorrectGuess);
            Assert.False(svc.Players[2].IsCorrectGuess);
            Assert.False(svc.Players[3].IsCorrectGuess);

            // service advanced
            Assert.Equal(2, svc.CurrentRound);
            Assert.Equal(1, svc.CurrentPlayerIndex);
        }

        [Fact]
        public void OtherPlayers_ExcludesCurrentPlayerAndKeepsOrder()
        {
            var svc = new GameStateService();
            svc.Players.Add(new Player { Name = "Current", Score = 0 });
            svc.Players.Add(new Player { Name = "G1", Score = 0, IsCorrectGuess = true });
            svc.Players.Add(new Player { Name = "G2", Score = 0, IsCorrectGuess = false });
            svc.Players.Add(new Player { Name = "G3", Score = 0, IsCorrectGuess = false });
            svc.StartGame();

            var vm = new ScoreTrackerPageModel(svc);

            // current player index 0 -> OtherPlayers should contain P1, P2
            Assert.Equal(3, vm.OtherPlayers.Count);
            Assert.Equal("G1", vm.OtherPlayers[0].Name);
            Assert.Equal("G2", vm.OtherPlayers[1].Name);
            Assert.Equal("G3", vm.OtherPlayers[2].Name);

            // change current player and verify
            vm.CurrentPlayerIndex = 1;
            Assert.Equal(3, vm.OtherPlayers.Count);
            Assert.Equal("Current", vm.OtherPlayers[0].Name);
            Assert.Equal("G2", vm.OtherPlayers[1].Name);
            Assert.Equal("G3", vm.OtherPlayers[2].Name);
        }
    }
}
