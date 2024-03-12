using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Laba6.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using System.Net.NetworkInformation;




namespace Laba6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public HomeController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

        }
        [HttpGet]
        [Route("current")]
        
        public async Task<IActionResult> GetCurrentWeather(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=fc50d49ff68b5d1c84b5af99bfb4bff3";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest($"Помилка запиту: {response.StatusCode}");
            }
            var weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();

            return Ok(FormatCurrentWeather(weatherData));
        }
        private string FormatCurrentWeather(WeatherData weatherData)
        {
            return $"**Погода в {weatherData.Sys.Country}, {weatherData.Sys.Name} :**\n\n" +
                   $"Температура: {weatherData.Main.Temp}°C\n" +
                   $"Вологість: {weatherData.Main.Humidity}%\n" +
                   $"Швидкість вітру: {weatherData.Wind.Speed} м/с";
        }

        [HttpGet]
        [Route("forecast")]

        public async Task<IActionResult> GetForecastWeather(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid=fc50d49ff68b5d1c84b5af99bfb4bff3&cnt=8";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest($"Помилка запиту: {response.StatusCode}");
            }
            var forecastData = await response.Content.ReadFromJsonAsync<ForecastData>();
            return Ok(FormatForecastWeather(forecastData));
        }

        private string FormatForecastWeather(ForecastData forecastData)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"**Прогноз погоди в {forecastData.Name} на {forecastData.List.Count}");

            foreach (var forecast in forecastData.List)
            {
                sb.AppendLine($"\n**Дата: {forecast.dt_txt}**");
                sb.AppendLine($"Температура: {forecast.Main.Temp}°C");
                sb.AppendLine($"Вологість: {forecast.Main.Humidity}");
                sb.AppendLine($"Швидкість вітру: {forecast.Wind.Speed} м/с");
            }

            return sb.ToString();
        }
    }
}
