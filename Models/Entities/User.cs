namespace BugTracker.Api.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public ICollection<DeadlineChangeRequest> DeadlineRequestsWhereAuthor { get; set; }
            = new List<DeadlineChangeRequest>();
        public ICollection<DeadlineChangeRequest> DeadlineRequestsWhereAssignee { get; set; }
            = new List<DeadlineChangeRequest>();
        public ICollection<Ticket> TicketsWhereAuthor { get; set; }
            = new List<Ticket>();
        public ICollection<Ticket> TicketsWhereAssignee { get; set; }
            = new List<Ticket>();
        public ICollection<Project> ProjectsWhereAuthor { get; set; }
            = new List<Project>();
        public ICollection<ProjectMember> ProjectMemberships { get; set; }
            = new List<ProjectMember>();
        public ICollection<Fix> FixesWhereAuthor { get; set; }
            = new List<Fix>();
        public ICollection<Fix> FixesWhereAssignee { get; set; }
            = new List<Fix>();
    }
}
