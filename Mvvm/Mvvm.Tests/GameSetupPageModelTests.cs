using Mvvm.PageModels;
using Mvvm.Services;
using System.Threading.Tasks;
using Xunit;

namespace Mvvm.Tests
{
    public class GameSetupPageModelTests
    {
        [Fact]
        public void StartGameCommand_Disabled_When_Less_Than_4_Players()
        {
            var svc = new GameStateService();
            var vm = new GameSetupPageModel(svc);

            svc.Players.Add(new Player { Name = "Player 1" });
            svc.Players.Add(new Player { Name = "Player 2" });
            svc.Players.Add(new Player { Name = "Player 3" });

            Assert.False(vm.StartGameCommand.CanExecute(null));
        }

        [Fact]
        public void StartGameCommand_Enabled_When_4_Players()
        {
            var svc = new GameStateService();
            var vm = new GameSetupPageModel(svc);

            svc.Players.Add(new Player { Name = "Player 1" });
            svc.Players.Add(new Player { Name = "Player 2" });
            svc.Players.Add(new Player { Name = "Player 3" });

            svc.Players.Add(new Player { Name = "Player 4" });

            Assert.True(vm.StartGameCommand.CanExecute(null));
        }

        [Fact]
        public void StartGameCommand_Enabled_Maximum_Players_10()
        {
            var svc = new GameStateService();
            var vm = new GameSetupPageModel(svc);

            // Add exactly 10 players -> StartGame should be allowed
            for (int i = 1; i <= 10; i++)
            {
                svc.Players.Add(new Player { Name = $"Player {i}" });
            }

            Assert.True(vm.StartGameCommand.CanExecute(null));

            // Add the 11th player -> StartGame should be disallowed
            svc.Players.Add(new Player { Name = "Player 11" });
            Assert.False(vm.StartGameCommand.CanExecute(null));
        }

        [Fact]
        public void AddPlayerCommand_Disabled_When_Reach_10Players()
        {
            var svc = new GameStateService();
            var vm = new GameSetupPageModel(svc);

            // With 9 players, AddPlayer should be allowed
            for (int i = 1; i <= 9; i++)
            {
                svc.Players.Add(new Player { Name = $"Player {i}" });
            }
            Assert.True(vm.AddPlayerCommand.CanExecute(null));

            // When reaching 10 players, AddPlayer should be disallowed
            svc.Players.Add(new Player { Name = "Player 10" });
            Assert.False(vm.AddPlayerCommand.CanExecute(null));
        }
    }
}
