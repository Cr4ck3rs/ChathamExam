using Moq;
using RestClientHelper.Abstractions;
using WeatherServices.WeatherApiWrappers.ForecastIo;
using WeatherServices.WeatherApiWrappers.ForecastIo.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class ForecastIoTests
    {
        [Fact]
        private async void WhenForeCastIoMethodIsCalledRestClientGetLocalWeatherShouldBeCalled()
        {
            //Arrange
            var restClientMock = new Mock<IRestClient<EndPointResponse>>();
            var forecastIo = new ForecastIo(restClientMock.Object) {ApiKey = "0"};

            // Act
            await forecastIo.GetLocalWeather(0, 0);

            // Verify
            restClientMock.Verify(t => t.CallListEndPoint(It.IsAny<string>()));
        }
    }
}