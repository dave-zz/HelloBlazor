using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DaveMarket.App.Services
{
    public interface IMarketHttpClient
    {
        Task<string> GetProduct();
    }
    public class MarketHttpClient : IMarketHttpClient
    {
        public HttpClient HttpClient { get; set; } = default!;

        public MarketHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<string> GetProduct()
        {
            return await HttpClient.GetStringAsync("weatherforecast");
        }
    }
}
