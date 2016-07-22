using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WeatherServices.Abstractions;
using RestClientHelper.Abstractions;
using WeatherServices.WeatherApiWrappers.Wunderground.Entities;
using WeatherServices.WeatherApiWrappers.Wunderground.Extensions;
using Forecast = WeatherServices.Models.Forecast;

namespace WeatherServices.WeatherApiWrappers.Wunderground
{
    /// <summary>
    /// Weather API wrapper implementation for Wunderground
    /// </summary>
    public class Wunderground : IWeatherApi
    {
        public string ApiKey { get; set; }

	    private readonly IRestClient<EndPointResponse> _restApiCaller;
	    public Wunderground(IRestClient<EndPointResponse> restApiCaller)
	    {
		    _restApiCaller = restApiCaller;
	    }

        /// <summary>
        /// Gets the list of forecasts
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
	    public async Task<IList<Forecast>> GetLocalWeather(double latitude, double longitude)
        {
	        var latlong = latitude.ToString(CultureInfo.InvariantCulture) + ',' +
	                      longitude.ToString(CultureInfo.InvariantCulture);
	        var url = $"http://api.wunderground.com/api/{ApiKey}/forecast10day/q/{latlong}.json";
            var result = await _restApiCaller.CallListEndPoint(url);

            //Limit the query to 8 days
            return result.Forecast?.Txt_Forecast?.ForecastDay == null
                ? new List<Forecast>()
                : result.Forecast.Txt_Forecast.ForecastDay.Where(day => day.Period < 16)
                    .Select(day => day.MapToForecast())
                    .ToList();
        }
    }
}
