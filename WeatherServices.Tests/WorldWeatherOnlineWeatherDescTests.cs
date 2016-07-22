using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class WorldWeatherOnlineWeatherDescTests
    {
        private const string Value = "value";

        [Fact]
        public void WhenWeatherDescTestsIsInitializedItsParametersShouldHaveCorrectValues()
        {
            var weatherDesc = new WeatherDesc
            {
                Value = Value
            };

            Assert.Equal(Value, weatherDesc.Value);
        }
    }
}