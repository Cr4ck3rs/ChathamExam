using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class WorldWeatherOnlineWeatherIconUrlTests
    {
        private const string Value = "value";

        [Fact]
        public void WhenWeatherIconUrlIsInitializedItsParametersShouldHaveCorrectValues()
        {
            var weatherIconUrl = new WeatherIconUrl
            {
                Value = Value
            };

            Assert.Equal(Value, weatherIconUrl.Value);
        }
    }
}