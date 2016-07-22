using Xunit;
using WeatherServices.Models;

namespace WeatherServices.Tests
{
    public class WeatherApisConfigTests
    {
        // Test data
        private static readonly WeaherApiOption[] Options = { new WeaherApiOption { Key = "Test", Name = "Name" } };

        [Fact]
        public void WhenInitializingWeatherApisConfigItsPropertiesShouldHaveCorrectValues()
        {
            var weatherApisConfig = new WeatherApisConfig
                            {
                                WeaherApiOption = Options
                            };

            Assert.Equal(Options, weatherApisConfig.WeaherApiOption);
        }
    }
}
