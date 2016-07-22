using System;
using Microsoft.Extensions.Caching.Memory;
using WeatherServices.Abstractions;

namespace WeatherServices.CacheImplementations
{
	public class MemoryCache<T> : ICache<T>
	{
		internal static readonly object CacheLock = new object();

		private readonly IMemoryCache _memoryCache;

		public MemoryCache(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public T Get(string cacheName, Func<T> func, int cacheTimeOutSeconds)
		{
			T result;
			if (_memoryCache.TryGetValue(cacheName, out result)) return (T)result;

			lock (CacheLock)
			{
				//Check to see if anyone wrote to the cache while we where waiting our turn to write the new value.
				if (_memoryCache.TryGetValue(cacheName, out result)) return (T) result;

				result = func();
				//The value still did not exist so we now write it in to the cache.
				Put(cacheName, cacheTimeOutSeconds, result);
			}

			return result;
		}

		public void Put(string cacheName, int cacheTimeOutSeconds, T data)
		{
			_memoryCache.Set(cacheName, data,
				new MemoryCacheEntryOptions()
					.SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
		}
	}
}