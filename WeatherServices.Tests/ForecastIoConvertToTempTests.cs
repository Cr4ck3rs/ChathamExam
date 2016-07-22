using WeatherServices.WeatherApiWrappers.ForecastIo.Utilities;
using Xunit;

namespace WeatherServices.Tests
{
    public class ForecastIoConvertToTempTests
    {
        [Fact]
        public void WhenConvert76FahrenheitToCelsiusIsCalled244444ShouldBeReturned()
        {
            Assert.Equal(ConvertTemp.ConvertFahrenheitToCelsius(76), 24.4444);
        }
    }
}