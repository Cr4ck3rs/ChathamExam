using System.Collections.Generic;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class WorldWeatherOnlineWeatherTests
    {
        private const string Date = "Today";
        private static readonly List<Hourly> Hourlies = new List<Hourly>();

        [Fact]
        public void WhenWeatherIsInitializedItsParametersShouldHaveTheCorrectValues()
        {
            var weather = new Weather
            {
                Hourly = Hourlies,
                Date = Date
            };

            Assert.Equal(Date, weather.Date);
            Assert.Equal(Hourlies, weather.Hourly);
        }
    }
}