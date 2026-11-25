namespace BugTracker.Api.Models.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;
    }
}
