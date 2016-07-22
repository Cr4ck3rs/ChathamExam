using System;
using System.Collections.Generic;
using WeatherServices.Models;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Extensions;
using Xunit;

namespace WeatherServices.Tests
{
    public class WorldWeatherOnlineExtensionsTests
    {

        private static readonly Weather Weather= new Weather
        {
            Date = "2016-07-20",
            Hourly = new List<Hourly>
            {
                new Hourly
                {
                    TempF = 85,
                    TempC = 30,
                    WeatherCode = 356,
                    WeatherDesc = new List<WeatherDesc>
                    {
                        new WeatherDesc
                        {
                            Value = "Patchy light drizzle"
                        }
                    }
                }
            }
        };
        private static readonly Forecast ExpectedResult = new Forecast
        {
            DayName = new DateTime(2016, 7, 20).ToString("dddd"),
            IconElement = "rain",
            TextForecastC = "Patchy light drizzle, with a temperature of 30C",
            TextForecastF = "Patchy light drizzle, with a temperature of 85F"
        };

        [Fact]
        public void WhenWeatherMapToForecastIsCalledItShouldReturnAForecastWithTheCorrectValue()
        {
            var result = Weather.MapToForecast();
            Assert.Equal(ExpectedResult.DayName, result.DayName);
            Assert.Equal(ExpectedResult.IconElement, result.IconElement);
            Assert.Equal(ExpectedResult.TextForecastC, result.TextForecastC);
            Assert.Equal(ExpectedResult.TextForecastF, result.TextForecastF);
        }

        [Fact]
        public void WhenWeatherMapToForecastIsCalledWithABadDateShouldThrowException()
        {
            //Arrange
            Weather.Date = "";

            //Act And Assert
            Assert.Throws<FormatException>(() => Weather.MapToForecast());
        }
    }
}