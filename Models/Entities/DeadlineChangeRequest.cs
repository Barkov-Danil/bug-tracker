using BugTracker.Api.Models.Entities.Enums;

namespace BugTracker.Api.Models.Entities
{
    public class DeadlineChangeRequest
    {
        public Guid Id { get; set; }
        public DateTimeOffset RequestedDeadline { get; set; }
        public string Reason { get; set; } = null!;
        public DeadlineRequestStatus Status { get; set; } = DeadlineRequestStatus.Pending;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
