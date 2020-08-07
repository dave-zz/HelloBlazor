using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

using HelloBlazor.Common.Model;

namespace HelloBlazor.Common.Services
{
    public class HttpWeatherService : IWeatherService
    {
        public HttpClient HttpClient { get; set; } = default!;

        public HttpWeatherService(HttpClient httpClient) =>
            HttpClient = httpClient;

        public async Task<List<WeatherForecast>> GetWeather() =>
            await HttpClient.GetFromJsonAsync<List<WeatherForecast>>("weatherforecast");

        public async Task CreateOrUpdateWeather(WeatherForecast forecast, CancellationToken ct) =>
            await HttpClient.PostAsJsonAsync("weatherforecast", forecast, ct);
    }
}
