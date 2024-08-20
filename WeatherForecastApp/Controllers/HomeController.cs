using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeatherForecastApp.Models;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WeatherService _weatherService;
        private readonly CityService _cityService;

        public HomeController(ILogger<HomeController> logger, WeatherService weatherService, CityService cityService)
        {
            _logger = logger;
            _weatherService = weatherService;
            _cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityService.GetAllCities();
            ViewBag.City = new SelectList(cities, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cityName)
        {
            if (cityName != null)
            {
                var response = await _weatherService.GetWeatherByCityAsync(cityName);
                var cities = await _cityService.GetAllCities();
                ViewBag.City = new SelectList(cities, "Name", "Name");
                return View(response);
            }
            return View();

        }

    }
}
