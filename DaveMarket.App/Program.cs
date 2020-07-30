using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DaveMarket.App.Services;
using DaveMarket.App.HttpHandlers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DaveMarket.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            #region typed httpclient
            builder.Services.AddScoped<MarketServerBearerTokenHandler>();
            builder.Services.AddHttpClient<IMarketHttpClient, MarketHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44361/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddHttpMessageHandler<MarketServerBearerTokenHandler>();
            #endregion

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = "https://dev-xa85-laa.auth0.com";
                options.ProviderOptions.ClientId = "WUYCq9bIB04Bs2wvTAdq3CGG5WLldA4j";
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.DefaultScopes.Add("openid");
                options.ProviderOptions.DefaultScopes.Add("read: weather");
            });

            builder.Services.AddApiAuthorization();
            await builder.Build().RunAsync();
        }
    }
}
