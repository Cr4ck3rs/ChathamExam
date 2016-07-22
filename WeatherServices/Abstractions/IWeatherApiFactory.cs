namespace WeatherServices.Abstractions
{
    /// <summary>
    /// Factory abstraction to get an IWeather API implementation, based on the provided source
    /// </summary>
	public interface IWeatherApiFactory
	{
        /// <summary>
        /// Implementation builder
        /// </summary>
        /// <param name="source">Parameter to decide which of the implementations to use</param>
        /// <returns></returns>
		IWeatherApi Make(int source);
	}

}
