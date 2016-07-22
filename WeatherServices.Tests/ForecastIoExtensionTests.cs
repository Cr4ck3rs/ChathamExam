using System;
using System.Globalization;
using Xunit;
using WeatherServices.WeatherApiWrappers.ForecastIo.Entities;
using WeatherServices.Models;
using WeatherServices.WeatherApiWrappers.ForecastIo.Extensions;

namespace WeatherServices.Tests
{
    public class ForecastIoExtensionTests
    {

        // Test data
        private static readonly Data Data = new Data
        {
            Icon = "cloudy" ,
            Summary = "Overcast throughout the day.",
            TemperatureMax = 77.77,
            TemperatureMin = 76,
            Time = 0
        };
        private static readonly Forecast ExpectedResult = new Forecast
        {
            DayName = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToString("dddd"),
            IconElement = "cloudy",
            TextForecastC = $"Overcast throughout the day. With temperatures ranging from {24.4444.ToString(CultureInfo.InvariantCulture)}C to {25.4278.ToString(CultureInfo.InvariantCulture)}C",
            TextForecastF = $"Overcast throughout the day. With temperatures ranging from {76.ToString(CultureInfo.InvariantCulture)}F to {77.77.ToString(CultureInfo.InvariantCulture)}F"
        };

        [Fact]
        public void WhenDataMapToForecastIsCalledItShouldReturnAForecastObjectWithExpectedValues()
        {
            var result = Data.MapToForecast();
            Assert.Equal(ExpectedResult.DayName, result.DayName);
            Assert.Equal(ExpectedResult.IconElement, result.IconElement);
            Assert.Equal(ExpectedResult.TextForecastC, result.TextForecastC);
            Assert.Equal(ExpectedResult.TextForecastF, result.TextForecastF);
        }

        [Fact]
        public void WhenLongToDateTimeIsCalledItShouldReturnTheProperDate()
        {
            Assert.Equal(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), long.Parse(0.ToString()).ToDateTime());
        }
        
    }
}
