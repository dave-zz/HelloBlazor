using HelloBlazor.Common.Model;

using Microsoft.EntityFrameworkCore;

namespace HelloBlazor.Common.Database
{
    public class HelloContext : DbContext
    {
        public DbSet<WeatherForecast> Forecasts { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=HelloContext.db");
    }
}
