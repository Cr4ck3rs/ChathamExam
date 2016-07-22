namespace WeatherServices.Models
{
    /// <summary>
    /// Forecast ViewModel with the Weather Data
    /// </summary>
    public class Forecast
    {
        /// <summary>
        /// The name of the day for which the forecast applies
        /// </summary>
        public string DayName { get; set; }

        /// <summary>
        /// Forecast Text with the data on Farenheit and Miles
        /// </summary>
        public string TextForecastF { get; set; }

        /// <summary>
        /// Forecast Text with the data on Celsius and Kilometers
        /// </summary>
        public string TextForecastC { get; set; }

        /// <summary>
        /// HTML tag with the icon element to be displayed
        /// </summary>
        public string IconElement { get; set; }
    }
}
