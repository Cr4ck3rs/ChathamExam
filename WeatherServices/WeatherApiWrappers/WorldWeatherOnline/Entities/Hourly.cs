using System.Collections.Generic;

namespace WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities
{
    public class Hourly
    {
        public int TempC { get; set; }
        public int TempF { get; set; }
        public int WeatherCode { get; set; }
        public List<WeatherDesc> WeatherDesc { get; set; }
        public List<WeatherIconUrl> WeatherIconUrl { get; set; }
    }
}
