namespace WeatherServices.WeatherApiWrappers.ForecastIo.Entities
{
    public class Data
    {
        public long Time { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
    }
}
