using System;

namespace WeatherServices.Abstractions
{
	public interface ICache<T>
	{
		T Get(string cacheName, Func<T> func, int cacheTimeOutSeconds);

		void Put(string cacheName, int cacheTimeOutSeconds, T data);
	}
}