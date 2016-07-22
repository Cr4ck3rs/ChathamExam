using System.Collections.Generic;

namespace WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities
{
    public class Weather
    {
        public string Date { get; set; }
        public List<Hourly> Hourly { get; set; }
    }
}
