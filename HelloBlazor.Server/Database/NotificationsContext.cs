using HelloBlazor.Common.Notifications;

using Microsoft.EntityFrameworkCore;

namespace HelloBlazor.Identity.Data
{
    public class NotificationsContext : DbContext
    {
        public DbSet<NotificationSubscription> NotificationSubscriptions { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=notifications.db");
    }
}
