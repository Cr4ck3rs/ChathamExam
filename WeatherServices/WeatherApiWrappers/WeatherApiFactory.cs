using System;
using WeatherServices.Abstractions;
using WeatherServices.Models;
using RestClientHelper.Clients;
using Microsoft.Extensions.Options;
using RestClientHelper.Abstractions;
using ForecastIoEntities = WeatherServices.WeatherApiWrappers.ForecastIo.Entities;
using WorldWeatherOnlineEntities = WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using WundegroundEntities = WeatherServices.WeatherApiWrappers.Wunderground.Entities;

namespace WeatherServices.WeatherApiWrappers
{
    /// <summary>
    /// Implementation of the Weather API's Factory
    /// </summary>
	public class WeatherApiFactory : IWeatherApiFactory
	{

		private readonly IOptions<WeatherApisConfig> _optionsAccessor;  //API Configurations
		private readonly IRestClient<ForecastIoEntities.EndPointResponse> _forecastClient;
		private readonly IRestClient<WundegroundEntities.EndPointResponse> _wunderClient;
		private readonly IRestClient<WorldWeatherOnlineEntities.EndPointResponse> _wwoClient;

		/// <summary>
		/// CTOR with the dependency injection of the options accessor
		/// </summary>
		/// <param name="optionsAccessor"></param>
		/// <param name="forecastClient"></param>
		/// <param name="wunderClient"></param>
		/// <param name="wwoClient"></param>
		public WeatherApiFactory(IOptions<WeatherApisConfig> optionsAccessor,
			IRestClient<ForecastIoEntities.EndPointResponse> forecastClient,
			IRestClient<WundegroundEntities.EndPointResponse> wunderClient,
			IRestClient<WorldWeatherOnlineEntities.EndPointResponse> wwoClient)
		{
			_optionsAccessor = optionsAccessor;
			_forecastClient = forecastClient;
			_wunderClient = wunderClient;
			_wwoClient = wwoClient;
		}

        /// <summary>
        /// API Wrapper generator
        /// </summary>
        /// <param name="source">Selected API Enum Value</param>
        /// <returns></returns>
		public IWeatherApi Make(int source)
		{
            // We get the current source's options
			var option = _optionsAccessor.Value.WeaherApiOption[source];
			if (!option.Name.Equals(((Source) source).ToString()))
				throw new Exception("Badly Configured Parameters");

            // Based on the source we initialize the desired wrapper and set it's KEY
			IWeatherApi implementation;
			switch ((Source) source)
			{
				case Source.ForecastIo:
					implementation = new ForecastIo.ForecastIo(_forecastClient);
					break;
				case Source.WeatherUnderground:
					implementation = new Wunderground.Wunderground(_wunderClient);
					break;
				case Source.WorldWeatherOnline:
					implementation = new WorldWeatherOnline.WorldWeatherOnline(_wwoClient);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(source), source, null);
			}
			implementation.ApiKey = option.Key;

			return implementation;
		}
	}
}
