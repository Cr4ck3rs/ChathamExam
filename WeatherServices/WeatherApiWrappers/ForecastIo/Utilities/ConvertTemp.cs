using System;

namespace WeatherServices.WeatherApiWrappers.ForecastIo.Utilities
{
    /// <summary>
    /// Temperature Helper
    /// </summary>
    public static class ConvertTemp
    {
        // Method to convert from F to C
        public static double ConvertFahrenheitToCelsius(double f)
        {
            return Math.Round((5.0 / 9.0) * (f - 32), 4);
        }
    }
}
