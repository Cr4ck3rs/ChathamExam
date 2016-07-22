using Xunit;
using System.Collections.Generic;
using WeatherServices.WeatherApiWrappers.ForecastIo.Entities;

namespace WeatherServices.Tests
{
    public class ForecastIoDailyTests
    {
        // Test data
        private static readonly List<Data> Data = new List<Data>();

        [Fact]
        public void WhenInitializingDailyItsPropertiesShouldHaveCorrectValues()
        {
            var daily = new Daily
                            {
                                Data = Data
                            };

            Assert.Equal(Data, daily.Data);
        }
    }
}
