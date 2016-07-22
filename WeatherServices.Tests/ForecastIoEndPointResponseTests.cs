using WeatherServices.WeatherApiWrappers.ForecastIo.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class ForecastIoEndPointResponseTests
    {
        private static readonly Daily Daily = new Daily();

        [Fact]
        public void WhenDailyIsInitializedItShouldHaveTheCorrectValues()
        {
            var endPointResponse = new EndPointResponse{Daily = Daily};
            Assert.Equal(Daily, endPointResponse.Daily);
        }
    }
}