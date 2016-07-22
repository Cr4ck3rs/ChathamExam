using System.Collections.Generic;

namespace WeatherServices.WeatherApiWrappers.Wunderground.Entities
{
    public class TxtForecast
    {
        public List<ForecastDay> ForecastDay { get; set; }
    }
}
