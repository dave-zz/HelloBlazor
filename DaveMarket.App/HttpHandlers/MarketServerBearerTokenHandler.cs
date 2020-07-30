using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DaveMarket.App.HttpHandlers
{
    public class MarketServerBearerTokenHandler : DelegatingHandler
    {
        public class ProtectedApiBearerTokenHandler : DelegatingHandler
        {
            private readonly IAccessTokenProvider TokenProvider;
            private readonly ILogger Logger;
            public ProtectedApiBearerTokenHandler(IAccessTokenProvider tokenProvider, ILogger logger)
            {
                TokenProvider = tokenProvider;
                Logger = logger;
            }

            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                // request the access token
                var tokenResult = await TokenProvider.RequestAccessToken();
                if (tokenResult.TryGetToken(out var token))
                {
                    request.Headers.Add("authorization", $"Bearer {token}");
                    Logger.LogInformation($"token {token}");
                }
                else {
                    Logger.LogInformation("no token");
                }
                // set the bearer token to the outgoing request

                // Proceed calling the inner handler, that will actually send the request
                // to our protected api

                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}