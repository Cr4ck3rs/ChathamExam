using System;
using System.Collections.Generic;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class WorldWeatherOnlineDataTests
    {
        private static readonly List<Weather> Weather = new List<Weather>();

        [Fact]
        public void WhenDataIsInitializedItShouldHaveItsAssignedValues()
        {
            var data = new Data
            {
                Weather = Weather
            };
            
            Assert.Equal(Weather, data.Weather);
        }

    }
}