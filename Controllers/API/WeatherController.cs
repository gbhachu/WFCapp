using WFCapp.Models;
using WFCapp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WFCapp.Controllers.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        public const string city = "Belfast";
        private readonly IConfiguration _configuration;

        public WeatherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public WeatherViewModel GetFiveDayForecast()
        {
            var weatherModel = new WeatherData();
            var result = weatherModel.GetWeather(city);

            return new WeatherViewModel(result);
        }
    }
}