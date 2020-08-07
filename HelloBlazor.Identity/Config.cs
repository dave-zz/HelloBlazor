using IdentityServer4.Models;
using System.Collections.Generic;

namespace HelloBlazor.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(name: "HelloBlazor.Server.Read"),
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("DaveMarketServer", "The market server"){ 
                    Scopes = { "HelloBlazor.Server.Read" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "HelloBlazor.App",
                    AllowedCorsOrigins = { "https://localhost:5000" },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "profile", "email", "phone", "address", "HelloBlazor.Server.Read" },
                    AllowOfflineAccess = true,
                    Enabled = true,
                    PostLogoutRedirectUris = { "https://localhost:5000/authentication/logout-callback" },
                    RedirectUris = { "https://localhost:5000/authentication/login-callback" },
                    RequirePkce = true,
                    RequireClientSecret = false,
                },
            };
    }
}