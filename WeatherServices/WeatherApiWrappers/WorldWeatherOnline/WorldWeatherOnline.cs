using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;
using WeatherServices.Models;
using RestClientHelper.Abstractions;
using WeatherServices.Abstractions;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Extensions;

namespace WeatherServices.WeatherApiWrappers.WorldWeatherOnline
{
    /// <summary>
    /// Weather API wrapper implementation for the WorldWeatherOnline Service
    /// </summary>
    public class WorldWeatherOnline : IWeatherApi
    {
        public string ApiKey { get; set; }

	    private readonly IRestClient<EndPointResponse> _restApiCaller;

	    public WorldWeatherOnline(IRestClient<EndPointResponse>  restApiCaller)
	    {
		    _restApiCaller = restApiCaller;
	    }

        /// <summary>
        /// Gets the list of forecasts from WorldWeatherOnline
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<IList<Forecast>> GetLocalWeather(double latitude, double longitude)
        {
	        var latlong = latitude.ToString(CultureInfo.InvariantCulture) + ',' +
	                      longitude.ToString(CultureInfo.InvariantCulture);
	        var url = $"http://api.worldweatheronline.com/premium/v1/weather.ashx?key={ApiKey}&q={latlong}&num_of_days=8&tp=24&format=json&cc=no&mca=no";
            var result = await _restApiCaller.CallListEndPoint(url);

            return result.Data?.Weather == null
                ? new List<Forecast>()
                : result.Data.Weather.Select(day => day.MapToForecast()).ToList();
        }
    }
}
