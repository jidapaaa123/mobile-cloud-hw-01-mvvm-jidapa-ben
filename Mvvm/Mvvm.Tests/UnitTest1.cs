using Mvvm.Services;

namespace Mvvm.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, 2 + 2);
        }
        [Fact]
        public void Fail1()
        {
            Assert.Equal(44, 2 + 2);
        }

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
    }
}
