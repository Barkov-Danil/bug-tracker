using BugTracker.Api.Models.Entities.Enums;

namespace BugTracker.Api.Models.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = null!;
        public NotificationType Type { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public ICollection<NotificationRecipient> Recipients { get; set; }
            = new List<NotificationRecipient>();
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}
