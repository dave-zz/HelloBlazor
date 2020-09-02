using System.Threading.Tasks;

using HelloBlazor.Common.Notifications;

namespace HelloBlazor.Common.Services
{
    public interface INotificationService
    {
        Task SubscribeToNotifications(NotificationSubscription subscription);
    }
}
