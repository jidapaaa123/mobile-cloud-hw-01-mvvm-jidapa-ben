using Mvvm.Services;
using Xunit;

namespace Mvvm.Tests
{
    public class GameStateServiceTests
    {
        [Fact]
        public void GameStateServiceInitialize_Pass()
        {
            var gameStateService = new GameStateService();
            Assert.NotNull(gameStateService.Players);
            Assert.False(gameStateService.HasGameStarted);
            Assert.Equal(1, gameStateService.CurrentRound);
            Assert.Equal(0, gameStateService.CurrentPlayerIndex);
            Assert.Empty(gameStateService.Players);
        }

        [Fact]
        public void GameStateServiceStartGame_Pass()
        {
            var g = new GameStateService();
            g.StartGame();
            Assert.True(g.HasGameStarted);
        }

        [Fact]
        public void GameStateServiceEndGame_Pass()
        {
            var g = new GameStateService();
            g.StartGame();
            Assert.True(g.HasGameStarted);
            g.EndGame();
            Assert.False(g.HasGameStarted);
        }

        [Fact]
        public void GameStateServiceResetGame_Pass()
        {
            var g = new GameStateService();
            g.StartGame();
            Assert.True(g.HasGameStarted);
            g.ResetGame();
            Assert.False(g.HasGameStarted);
        }

        [Fact]
        public void GameStateServiceNextRound_Pass_NoWrapAroundCurrentPlayerIndex()
        {
            var g = new GameStateService();
            g.Players.Add(new Mvvm.PageModels.Player { Name = "Player 1" });
            g.Players.Add(new Mvvm.PageModels.Player { Name = "Player 2" });
            g.Players.Add(new Mvvm.PageModels.Player { Name = "Player 3" });
            g.StartGame();

            Assert.Equal(1, g.CurrentRound);
            Assert.Equal(0, g.CurrentPlayerIndex);
            g.NextRound();

            Assert.Equal(2, g.CurrentRound);
            Assert.Equal(1, g.CurrentPlayerIndex);
        }

        [Fact]
        public void GameStateServiceNextRound_Pass_WrapAroundCurrentPlayerIndex()
        {
            var g = new GameStateService();
            g.Players.Add(new Mvvm.PageModels.Player { Name = "Player 1" });
            g.Players.Add(new Mvvm.PageModels.Player { Name = "Player 2" });
            g.Players.Add(new Mvvm.PageModels.Player { Name = "Player 3" });
            g.StartGame(); // on Round 1

            g.NextRound(); // on Round 2
            g.NextRound(); // on Round 3
            g.NextRound(); // on Round 4
            Assert.Equal(4, g.CurrentRound);
            Assert.Equal(0, g.CurrentPlayerIndex);
        }
    }
}