using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using RestClientHelper.Abstractions;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using Xunit;

namespace WeatherServices.Tests
{
    public class WorldWeatherOnlineTests
    {
        [Fact]
        private async void WhenWorldWeatherOnlineMethodIsCalledRestClientGetLocalWeatherShouldBeCalled()
        {
            //Arrange
            var restClientMock = new Mock<IRestClient<EndPointResponse>>();
	        restClientMock.Setup(o => o.CallListEndPoint(It.IsAny<string>()))
		        .ReturnsAsync(new EndPointResponse());
            var worldWeatherOnline = new WorldWeatherOnline(restClientMock.Object) { ApiKey = "0" };

            // Act
            await worldWeatherOnline.GetLocalWeather(0, 0);

            // Verify
            restClientMock.Verify(t => t.CallListEndPoint(It.IsAny<string>()));
        }
    }
}