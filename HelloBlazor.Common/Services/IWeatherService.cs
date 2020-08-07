using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using HelloBlazor.Common.Model;

namespace HelloBlazor.Common.Services
{
    public interface IWeatherService
    {
        Task<List<WeatherForecast>> GetWeather();
        Task CreateOrUpdateWeather(WeatherForecast forecast, CancellationToken ct);
    }
}
