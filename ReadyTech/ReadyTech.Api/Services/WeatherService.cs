using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ReadyTech.Api.Configurations;
using ReadyTech.Api.Models;
using ReadyTech.Api.Services.Interfaces;

namespace ReadyTech.Api.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherApiConfiguration _weatherApiConfig;

        public WeatherService(IOptions<WeatherApiConfiguration> options)
        {
            _weatherApiConfig = options.Value;
        }

        public async Task<Weather> GetTemperatureFromCoordinates(string latitude, string longitude)
        {
            var client = new HttpClient();

            using var response = await client.GetAsync($"{_weatherApiConfig.ApiUri}?key={_weatherApiConfig.ApiKey}&q={latitude},{longitude}");
            var responseBody = await response.Content.ReadAsStringAsync();

            var jObj = JObject.Parse(responseBody);

            return new Weather { TemperatureCelcius = Convert.ToDouble(jObj["current"]["temp_c"]) };
        }
    }
}
