using System.Text.Json;
using Newtonsoft.Json;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public class CityService
    {
        private readonly IWebHostEnvironment _webHost;

        public CityService(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public async Task<List<City>> GetAllCities()
        {
            var path = Path.Combine(_webHost.WebRootPath, "cities.json");
            var json = await File.ReadAllTextAsync(path);

            return JsonConvert.DeserializeObject<List<City>>(json);
        }
    }
}
