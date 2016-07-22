using System;
using System.Globalization;
using WeatherServices.Models;
using WeatherServices.WeatherApiWrappers.ForecastIo.Entities;
using WeatherServices.WeatherApiWrappers.ForecastIo.Utilities;

namespace WeatherServices.WeatherApiWrappers.ForecastIo.Extensions
{
    public static class Extensions
    {

        /// <summary>
        /// Extension on the Long Data Type to convert it to DateTime
        /// </summary>
        /// <returns>The correspondant DateTime</returns>
        public static DateTime ToDateTime(this long input)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixEpoch.AddSeconds(input);
        }

        /// <summary>
        /// Extension to map the wrapper model with the desired data to
        /// </summary>
        /// <returns></returns>
        public static Forecast MapToForecast(this Data model)
        {
            return new Forecast
            {
                DayName = model.Time.ToDateTime().ToString("dddd"),
                TextForecastF = $"{model.Summary} With temperatures ranging from {model.TemperatureMin.ToString(CultureInfo.InvariantCulture)}F to {model.TemperatureMax.ToString(CultureInfo.InvariantCulture)}F",
                TextForecastC = $"{model.Summary} With temperatures ranging from {ConvertTemp.ConvertFahrenheitToCelsius(model.TemperatureMin).ToString(CultureInfo.InvariantCulture)}C " +
                                $"to {ConvertTemp.ConvertFahrenheitToCelsius(model.TemperatureMax).ToString(CultureInfo.InvariantCulture)}C",
                IconElement = model.Icon
            };
        }
    }
}
