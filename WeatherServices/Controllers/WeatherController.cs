using System.Collections.Generic;
using WeatherServices.Abstractions;
using WeatherServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace WeatherServices.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {

	    private readonly IWeatherApiFactory _weatherApiFactory; //Weather API Factory to be injected
        private readonly ICache<IList<Forecast>> _cache;

	    /// <summary>
	    /// CTOR with the DI
	    /// </summary>
	    /// <param name="weatherApiFactory">Weather API Wrapper Factory to be injected</param>
	    /// <param name="cache"></param>
	    public WeatherController(IWeatherApiFactory weatherApiFactory, ICache<IList<Forecast>> cache)
	    {
		    _weatherApiFactory = weatherApiFactory;
		    _cache = cache;
	    }

        // GET //provider/2/latitude/37.8267/longitude/-122.423
        /// <summary>
        /// Method to get the Next Weather Forecast for today and the next 7 days
        /// </summary>
        /// <param name="source">Provider's Enum Value to use</param>
        /// <param name="latitude">Latitude to query</param>
        /// <param name="longitude">Longitude to query</param>
        /// <returns>List of 8 Forecasts's ViewModel</returns>
        [HttpGet("provider/{source:int}/latitude/{latitude:double}/longitude/{longitude:double}")]
        public IList<Forecast> Get(int source, double latitude, double longitude)
        {
            // Get our data from cache or API
            var cacheKey = $"query-{source}-{latitude}-{longitude}";
            var result = _cache.Get(cacheKey,
	            () => _weatherApiFactory.Make(source).GetLocalWeather(latitude, longitude).Result,
	            5);

            return result;
        }
    }
}
