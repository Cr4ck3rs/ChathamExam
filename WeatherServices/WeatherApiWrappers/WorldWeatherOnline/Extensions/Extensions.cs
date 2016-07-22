using System;
using System.Globalization;
using WeatherServices.Models;
using WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using System.Linq;

namespace WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Extensions
{
    public static class Extensions
    {

        public static string MapToSkycon(this int weatherCode)
        {
            switch (weatherCode)
            {
                case 113:
                    return Constants.ClearDayIcon;
                case 116:
                    return Constants.PartlyCloudyDayIcon;
                case 119:
                case 122:
                case 200:
                    return Constants.CloudyIcon;
                case 143:
                case 248:
                case 260:
                    return Constants.FogIcon;
                case 182:
                case 281:
                case 284:
                case 311:
                case 314:
                case 317:
                case 320:
                case 350:
                case 362:
                case 365:
                case 374:
                case 377:
                    return Constants.SleetIcon;
                case 179:
                case 227:
                case 230:
                case 323:
                case 326:
                case 329:
                case 332:
                case 335:
                case 338:
                case 368:
                case 371:
                case 392:
                case 395:
                    return Constants.SnowIcon;
                case 176:
                case 185:
                case 263:
                case 266:
                case 293:
                case 296:
                case 299:
                case 302:
                case 305:
                case 308:
                case 353:
                case 356:
                case 359:
                case 386:
                case 389:
                    return Constants.RainIcon;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Extension to map the wrapper model with the desired data to
        /// </summary>
        /// <returns></returns>
        public static Forecast MapToForecast(this Weather model)
        {
            var dateParams = model.Date.Split('-');
            return new Forecast
            {
                DayName = new DateTime(int.Parse(dateParams[0]), int.Parse(dateParams[1]), int.Parse(dateParams[2])).ToString("dddd"),
                TextForecastF = $"{model.Hourly.FirstOrDefault().WeatherDesc.FirstOrDefault().Value}, with a temperature of {model.Hourly.FirstOrDefault().TempF.ToString(CultureInfo.InvariantCulture)}F",
                TextForecastC = $"{model.Hourly.FirstOrDefault().WeatherDesc.FirstOrDefault().Value}, with a temperature of {model.Hourly.FirstOrDefault().TempC.ToString(CultureInfo.InvariantCulture)}C",
                IconElement = model.Hourly.FirstOrDefault().WeatherCode.MapToSkycon()
            };
        }
    }
}
