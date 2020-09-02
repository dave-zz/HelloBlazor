using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using HelloBlazor.Common.Notifications;

namespace HelloBlazor.Common.Services
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient httpClient;

        public NotificationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await httpClient.PutAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }
    }
}
