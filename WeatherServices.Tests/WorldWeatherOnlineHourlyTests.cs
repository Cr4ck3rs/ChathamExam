using System.Collections.Generic;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class WorldWeatherOnlineHourlyTests
    {
        private const int TempC = 12;
        private const int TempF = 33;
        private const int WeatherCode = 113;
        private static readonly List<WeatherDesc> WeatherDescs = new List<WeatherDesc>();
        private static readonly List<WeatherIconUrl> WeatherIconUrls = new List<WeatherIconUrl>();

        [Fact]
        public void WhenHourlyIsInitializedItsParametersShouldHaveTheCorrectValue()
        {
            var hourly = new Hourly
            {
                WeatherIconUrl = WeatherIconUrls,
                WeatherDesc = WeatherDescs,
                TempF = TempF,
                TempC = TempC,
                WeatherCode = WeatherCode
            };

            Assert.Equal(TempF, hourly.TempF);
            Assert.Equal(TempC, hourly.TempC);
            Assert.Equal(WeatherCode, hourly.WeatherCode);
            Assert.Equal(WeatherDescs, hourly.WeatherDesc);
            Assert.Equal(WeatherIconUrls, hourly.WeatherIconUrl);
        }
    }
}