using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// Модель відповіді API
public class APIResponse<T>
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public List<T> Data { get; set; }
}

// Клас клієнта API
public class APIClient
{
    private readonly HttpClient _client;

    public APIClient(string apiKey)
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // Метод для отримання даних за допомогою GET запиту без параметрів
    public async Task<APIResponse<string>> GetWeather(string cityName)
    {
        var response = new APIResponse<string>();

        try
        {
            HttpResponseMessage httpResponse = await _client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=fc50d49ff68b5d1c84b5af99bfb4bff3");
            httpResponse.EnsureSuccessStatusCode();

            string responseData = await httpResponse.Content.ReadAsStringAsync();
            response.Data = new List<string> { responseData };
            response.StatusCode = (int)httpResponse.StatusCode;
            response.Message = "Success";
        }
        catch (HttpRequestException ex)
        {
            response.StatusCode = 500;
            response.Message = $"Error: {ex.Message}";
        }

        return response;
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "fc50d49ff68b5d1c84b5af99bfb4bff3";
        var client = new APIClient(apiKey);

        // Виклик методу API для отримання погоди для міста
        var cityName = "Kyiv"; // Приклад назви міста
        var weatherResponse = await client.GetWeather(cityName);
        Console.WriteLine($"Weather Data: Status Code - {weatherResponse.StatusCode}, Message - {weatherResponse.Message}");

        // Тут можна додати інші виклики методів API для отримання погоди для інших міст
    }
}
