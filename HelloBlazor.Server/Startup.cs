using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelloBlazor.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            #region Add CORS default policy
            services.AddCors(options => options.AddPolicy("Default", builder => builder
                                .WithOrigins("https://localhost:5000")
                                .AllowAnyMethod()
                                .AllowAnyHeader()));
            services.AddControllers();
            #endregion

            #region Protect API with JWT access tokens
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            //.AddJwtBearer(options =>
            //{
            //    options.Authority = "https://localhost:4999";
            //    options.Audience = "DaveMarketServer";
            //});
            #endregion
        }

        public void Configure(IApplicationBuilder app) => 
            app.UseDeveloperExceptionPage()
            .UseHttpsRedirection()
            .UseCors("Default")
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
    }
}
