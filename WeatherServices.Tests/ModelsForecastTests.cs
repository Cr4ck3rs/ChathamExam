using Xunit;
using WeatherServices.Models;

namespace WeatherServices.Tests
{
    public class ModelsForecastTests
    {
        // Test data
        private const string Dayname = "Today";
        private const string TextForecastF = "Nice Day with 134F";
        private const string TextForecastC = "Nice Day with 52C";
        private const string IconElement = "<img href='/test.png'/>";

        [Fact]
        public void WhenInitializingForecastItsPropertiesShouldHaveCorrectValues()
        {
            var forecast = new Forecast
                            {
                                DayName = Dayname,
                                TextForecastF = TextForecastF,
                                TextForecastC = TextForecastC,
                                IconElement = IconElement
                            };

            Assert.Equal(Dayname, forecast.DayName);
            Assert.Equal(TextForecastF, forecast.TextForecastF);
            Assert.Equal(TextForecastC, forecast.TextForecastC);
            Assert.Equal(IconElement, forecast.IconElement);
        }
    }
}
