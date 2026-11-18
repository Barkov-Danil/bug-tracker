using BugTracker.Api.Models.Entities.Enums;

namespace BugTracker.Api.Models.Entities
{
    public class Fix
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public string CommitHash { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public FixStatus Status { get; set; } = FixStatus.Pending;

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}
