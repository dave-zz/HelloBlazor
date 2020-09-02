using System.ComponentModel.DataAnnotations;

namespace HelloBlazor.Common.Notifications
{
    public class NotificationSubscription
    {
        [Key]
        public int NotificationSubscriptionId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string P256dh { get; set; } = string.Empty;

        public string Auth { get; set; } = string.Empty;
    }
}
