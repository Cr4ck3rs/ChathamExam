using Xunit;

namespace RestClientHelper.Tests
{    
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }
        
        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
