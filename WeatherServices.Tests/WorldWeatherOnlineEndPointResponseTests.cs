using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class WorldWeatherOnlineEndPointResponseTests
    {
        private static readonly Data Data = new Data();

        [Fact]
        public void WhenEndPointResponseIsInitializedItShouldHaveTheCorrectProperties()
        {
            var endPointResponse = new EndPointResponse {Data = Data};

            Assert.Equal(Data, endPointResponse.Data);
        }

    }
}