using System;
using System.Globalization;
using System.Threading.Tasks;

using HelloBlazor.Common.Services;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace HelloBlazor.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            #region OAuth + OIDC
            builder.Services.AddOidcAuthentication(options =>
            {
                //builder.Configuration.Bind("Identity", options.ProviderOptions);
            });
            #endregion

            #region Typed HttpClient
            builder.Services.AddHttpClient<IWeatherService, HttpWeatherService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }); // ASP.NET Core middleware <3  <3  <3
                //    .AddHttpMessageHandler(sp =>
                //{
                //    var handler = sp.GetService<AuthorizationMessageHandler>()
                //        .ConfigureHandler(
                //            authorizedUrls: new[] { "https://localhost:5001" },
                //            scopes: new[] { "HelloBlazor.Server.Read" });
                //    return handler;
                //});
            #endregion

            #region Localization
            //builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            //var host = builder.Build();
            //var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            //var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
            //if (result != null)
            //{
            //    var culture = new CultureInfo(result);
            //    CultureInfo.DefaultThreadCurrentCulture = culture;
            //    CultureInfo.DefaultThreadCurrentUICulture = culture;
            //}

            //await host.RunAsync();
            #endregion

            await builder.Build().RunAsync();
        }
    }
}
