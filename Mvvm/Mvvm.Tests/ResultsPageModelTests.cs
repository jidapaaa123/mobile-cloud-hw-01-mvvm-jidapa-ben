using Xunit;
using Mvvm.PageModels;
using Mvvm.Services;

namespace Mvvm.Tests
{
    public class ResultsPageModelTests
    {
        [Fact]
        public void ResultString_For_1_Winner()
        {
            var svc = new GameStateService();
            svc.Players.Add(new Player { Name = "Alice", Score = 10 });
            svc.Players.Add(new Player { Name = "Bob", Score = 5 });

            var vm = new ResultsPageModel(svc);

            Assert.Equal("Alice with the score of 10", vm.ResultsString);
        }

        [Fact]
        public void ResultString_For_Tied_Winners()
        {
            var svc = new GameStateService();
            svc.Players.Add(new Player { Name = "Alice", Score = 8 });
            svc.Players.Add(new Player { Name = "Bob", Score = 8 });
            svc.Players.Add(new Player { Name = "Carol", Score = 3 });

            var vm = new ResultsPageModel(svc);

            Assert.Equal("Alice, Bob with the score of 8", vm.ResultsString);
        }
    }
}
