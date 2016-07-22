using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using RestClientHelper.Abstractions;
using WeatherServices.Abstractions;
using WeatherServices.Models;
using WeatherServices.WeatherApiWrappers.ForecastIo.Entities;
using WeatherServices.WeatherApiWrappers.ForecastIo.Extensions;

namespace WeatherServices.WeatherApiWrappers.ForecastIo
{
    /// <summary>
    /// Weather API wrapper implementation for the Forecast.io Service
    /// </summary>
    public class ForecastIo : IWeatherApi
    {
        public string ApiKey { get; set; }

	    private readonly IRestClient<EndPointResponse> _restApiCaller;
        /// <summary>
        /// CTOR with the DI
        /// </summary>
        /// <param name="restApiCaller"></param>
	    public ForecastIo(IRestClient<EndPointResponse> restApiCaller)
	    {
		    _restApiCaller = restApiCaller;
	    }

        /// <summary>
        /// Gets the list of forecasts from Forecast.io
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<IList<Forecast>> GetLocalWeather(double latitude, double longitude)
        {
	        var latlong = latitude.ToString(CultureInfo.InvariantCulture) +
	                      ',' + longitude.ToString(CultureInfo.InvariantCulture);
            var url = $"https://api.forecast.io/forecast/{ApiKey}/{latlong}?exclude=currently,minutely,hourly,alerts,flags";
            var result = await _restApiCaller.CallListEndPoint(url);

            //Return the result parsed into the view model
            return result?.Daily?.Data == null
                ? new List<Forecast>()
                : result.Daily.Data.Select(day => day.MapToForecast()).ToList();
        }
    }
}
