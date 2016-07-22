using System;
using WeatherServices.WeatherApiWrappers.Wunderground.Entities;
using ForecastEntity = WeatherServices.Models.Forecast;

namespace WeatherServices.WeatherApiWrappers.Wunderground.Extensions
{
    public static class Extensions
    {

        public static string MapToSkycon(this string icon)
        {
            switch (icon)
            {
                case "chanceflurries":
                case "flurries":
                case "nt_chanceflurries":
                case "nt_flurries":
                    return Constants.WindIcon;
                case "chancerain":
                case "chancetstorms":
                case "rain":
                case "nt_chancerain":
                case "tstorms":
                case "nt_tstorms":
                case "nt_rain":
                    return Constants.RainIcon;
                case "chancesleet":
                case "nt_chancesleet":
                case "sleet":
                case "nt_sleet":
                    return Constants.SleetIcon;
                case "chancesnow":
                case "snow":
                case "nt_chancesnow":
                case "nt_chancetstorms":
                case "nt_snow":
                    return Constants.SnowIcon;
                case "clear":
                case "hazy":
                case "mostlysunny":
                case "sunny":
                case "unknown":
                    return Constants.ClearDayIcon;
                case "cloudy":
                case "mostlycloudy":
                case "nt_mostlycloudy":
                case "nt_cloudy":
                    return Constants.CloudyIcon;
                case "fog":
                case "nt_fog":
                    return Constants.FogIcon;
                case "partlycloudy":
                case "partlysunny":
                    return Constants.PartlyCloudyDayIcon;
                case "nt_clear":
                case "nt_hazy":
                case "nt_mostlysunny":
                case "nt_sunny":
                case "nt_unknown":
                    return Constants.ClearNightIcon;
                case "nt_partlycloudy":
                case "nt_partlysunny":
                    return Constants.PartlyCloudyNightIcon;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Extension to map the wrapper model with the desired data to
        /// </summary>
        /// <returns></returns>
        public static ForecastEntity MapToForecast(this ForecastDay model)
        {
            return new ForecastEntity
            {
                DayName = model.Title,
                TextForecastF = $"{model.FctText}",
                TextForecastC = $"{model.FctText_Metric}",
                IconElement = model.Icon.MapToSkycon()
            };
        }
    }
}
