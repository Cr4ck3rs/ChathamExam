# Test Cases Definition

## RestClientHelper Tests

### HttpRestApiClientTest

  When HttpRestApiClient with type JsonArray is given a valid url it should return a JsonArray
	When HttpRestApiClient with type JsonArray is given an invalid url it should return the default value of JsonArray
	When HttpRestApiClient with type JsonArray is given a know test url it should return the expected result


## WeatherServices Tests

### X Models

#### X Forecast

  X WHen Forecast is initialized, it should have the values it was assigned

#### X WeatherApiOption

  X WHen WeatherApiOption is initialized, it should have the values it was assigned

####X WeatherApiConfig

  X WHen WeatherApiConfig is initialized, it should have the values it was assigned

ForecastIo

  X Daily

		WHen Daily is initialized, it should have the values it was assigned

	X Data

		WHen Data is initialized, it should have the values it was assigned

	X Extensions

		When Data.MapToForecast is called it should return a Forecast object with the expected values

		When Long.ToDateTime is called it should return the expected DateTime

	X EndPointResponse

		WHen EndPointResponse is initialized, it should have the values it was assigned

	X ConvertToTemp

		WHen ConvertFarenheitToCelsius is called, it should return the expected value

	X ForecastIo

		WHen ForecastIo GetLocalWeather is called, IRestClient.CallListEndPoint method should be called

WorldWeatherOnline

	X Data

		WHen Data is initialized, it should have the values it was assigned

	X EndPointResponse

		WHen EndPointResponse is initialized, it should have the values it was assigned

	X Hourly

		WHen HOurly is initialized, it should have the values it was assigned

	X WeatherDesc

		WHen WeatherDesc is initialized, it should have the values it was assigned

	X WeatherIconUrl

		WHen WeatherIconUrl is initialized, it should have the values it was assigned

	X Weather

		WHen Weather is initialized, it should have the values it was assigned

	X Extensions

		When Weather.MapToForecast is called it should return a Forecast object with the expected values

	X WorldWeatherOnline

		WHen WorldWeatherOnline GetLocalWeather is called, IRestClient.CallListEndPoint method should be called

Wunderground

	Forecast

		WHen Forecast is initialized, it should have the values it was assigned

	EndPointResponse

		WHen EndPointResponse is initialized, it should have the values it was assigned

	ForecastDay

		WHen ForecastDay is initialized, it should have the values it was assigned

	TxtForecast

		WHen TxtForecast is initialized, it should have the values it was assigned

	Extensions

		When ForecastDay.MapToForecast is called it should return a Forecast object with the expected values

	Wunderground

		WHen Wunderground GetLocalWeather is called, IRestClient.CallListEndPoint method should be called

CacheManager

	When Get Method is called the first time ICache<T>.Get ICache<T>.Put should have been called

	When Get Method is called the second time ICache<T>.Gettime ICache<T>.Put should not have been called

WeatherApiFactory

	When Make is called with a source it should return the expected implementation of IWeatherApi

	WHen Make is called with an invalid source source it should throw an ArgumentOutOfRangeException

	When Make is predetermined IOptions without APIKEYS, it should Throw Exception

Controller

	When get method called return array of Forecasts

Weather
