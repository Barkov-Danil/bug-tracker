using BugTracker.Api.Models.Entities.Enums;

namespace BugTracker.Api.Models.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TicketStatus Status { get; set; } = TicketStatus.Free;
        public TicketPriority Priority { get; set; } = TicketPriority.Low;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? ClosedAt { get; set; }
        public DateTimeOffset Deadline { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public ICollection<Fix> Fixes { get; set; } = new List<Fix>();
        public ICollection<DeadlineChangeRequest> DeadlineChangeRequests { get; set; } =
            new List<DeadlineChangeRequest>();
        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;
        public Guid? AssigneeId { get; set; }
        public User? Assignee { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Notification> Notifications { get; set; }
            = new List<Notification>();
    }
}
