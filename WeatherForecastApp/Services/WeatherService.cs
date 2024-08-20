using Newtonsoft.Json;
using System.Net.Http;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = @"4096cd023bcacfd13fd039ad133f7dbf";
        public WeatherService(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<WeatherResponse> GetWeatherByCityAsync(string cityName)
        {
            string requestUrl =
                $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(jsonResponse);
            }

            return null;
        }
    }
}
