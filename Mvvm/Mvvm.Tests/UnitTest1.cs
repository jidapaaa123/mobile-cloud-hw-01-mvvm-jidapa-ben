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
    }
}
