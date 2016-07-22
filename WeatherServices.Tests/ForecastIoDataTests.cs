using Xunit;
using WeatherServices.WeatherApiWrappers.ForecastIo.Entities;

namespace WeatherServices.Tests
{
    public class ForecastIoDataTests
    {
        // Test data
        private const long Time = 1234567890123;
        private const string Summary = "Nice Day with 134F";
        private const string Icon = "Nice Day";
        private const double TemperatureMin = 110.34;
        private const double TemperatureMax = 456.32;

        [Fact]
        public void WhenInitializingDataItsPropertiesShouldHaveCorrectValues()
        {
            var data = new Data
                            {
                                Time = Time,
                                Summary = Summary,
                                Icon = Icon,
                                TemperatureMin = TemperatureMin,
                                TemperatureMax = TemperatureMax
                            };

            Assert.Equal(Time, data.Time);
            Assert.Equal(Summary, data.Summary);
            Assert.Equal(Icon, data.Icon);
            Assert.Equal(TemperatureMin, data.TemperatureMin);
            Assert.Equal(TemperatureMax, data.TemperatureMax);
        }
    }
}
