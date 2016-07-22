namespace WeatherServices.WeatherApiWrappers.Wunderground.Entities
{
    public class ForecastDay
    {
        public int Period { get; set; }
        public string Icon_Url { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string FctText { get; set; }
        public string FctText_Metric { get; set; }
    }
}
