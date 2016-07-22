using WeatherServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherServices.Abstractions
{
    /// <summary>
    /// Abstraction of a Weather API wrapper
    /// </summary>
    public interface IWeatherApi
    {
        /// <summary>
        /// API Key to use in the call
        /// </summary>
	    string ApiKey { get; set; }

        /// <summary>
        /// Method to get the weather, based on the provided latitude and longitude
        /// </summary>
        /// <param name="latitude">Latitude for the query</param>
        /// <param name="longitude">Longitude for the query</param>
        /// <returns>List of our FrontEnd ViewModel with the parsed weather data</returns>
	    Task<IList<Forecast>> GetLocalWeather(double latitude, double longitude);
    }
}
