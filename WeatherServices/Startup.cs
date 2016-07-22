using System.Collections.Generic;
using WeatherServices.Abstractions;
using WeatherServices.Models;
using WeatherServices.WeatherApiWrappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestClientHelper.Abstractions;
using RestClientHelper.Clients;
using WeatherServices.CacheImplementations;
using ForecastIoEntities = WeatherServices.WeatherApiWrappers.ForecastIo.Entities;
using WorldWeatherOnlineEntities = WeatherServices.WeatherApiWrappers.WorldWeatherOnline.Entities;
using WundegroundEntities = WeatherServices.WeatherApiWrappers.Wunderground.Entities;

namespace WeatherServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

	        // Add Cors
	        services.AddCors(options =>
	        {
		        options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
	        });

	        // Add framework services.
            services.AddMvc();

	        // Add options DI.
	        services.Configure<WeatherApisConfig>(Configuration.GetSection("WeatherApisConfig"));

	        // Add Implementations DI
	        services.AddTransient<IWeatherApiFactory, WeatherApiFactory>();
	        services.AddTransient<ICache<IList<Forecast>>, MemoryCache<IList<Forecast>>>();

	        services.AddTransient<IRestClient<ForecastIoEntities.EndPointResponse>,
		        HttpRestApiClient<ForecastIoEntities.EndPointResponse>>();
	        services.AddTransient<IRestClient<WundegroundEntities.EndPointResponse>,
		        HttpRestApiClient<WundegroundEntities.EndPointResponse>>();
	        services.AddTransient<IRestClient<WorldWeatherOnlineEntities.EndPointResponse>,
		        HttpRestApiClient<WorldWeatherOnlineEntities.EndPointResponse>>();

	        // Add Memory Cache Implementation
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

	        app.UseCors("AllowAll");

	        app.UseMvc();
        }
    }
}
