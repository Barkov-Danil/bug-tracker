using BugTracker.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Fix> Fixes { get; set; }
        public DbSet<DeadlineChangeRequest> DeadlineChangeRequests { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Author)
                .WithMany(u => u.TicketsWhereAuthor)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Assignee)
                .WithMany(u => u.TicketsWhereAssignee)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeadlineChangeRequest>()
                .HasOne(d => d.RequestedBy)
                .WithMany(u => u.DeadlineRequestsWhereAuthor)
                .HasForeignKey(d => d.RequestedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DeadlineChangeRequest>()
                .HasOne(d => d.Reviewer)
                .WithMany(u => u.DeadlineRequestsWhereAssignee)
                .HasForeignKey(d => d.ReviewerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DeadlineChangeRequest>()
                .HasOne(d => d.Ticket)
                .WithMany(t => t.DeadlineChangeRequests)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fix>()
                .HasOne(f => f.Author)
                .WithMany(u => u.FixesWhereAuthor)
                .HasForeignKey(f => f.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fix>()
                .HasOne(f => f.Tester)
                .WithMany(u => u.FixesWhereAssignee)
                .HasForeignKey(f => f.TesterId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Fix>()
                .HasOne(f => f.Ticket)
                .WithMany(t => t.Fixes)
                .HasForeignKey(f => f.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectMember>()
                .HasKey(pm => new { pm.ProjectId, pm.UserId });

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.Members)
                .HasForeignKey(pm => pm.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMemberships)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Ticket)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(u => u.CommentsWhereAuthor)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NotificationRecipient>()
                .HasKey(nr => new { nr.NotificationId, nr.UserId });

            modelBuilder.Entity<NotificationRecipient>()
                .HasOne(nr => nr.Notification)
                .WithMany(n => n.Recipients)
                .HasForeignKey(nr => nr.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NotificationRecipient>()
                .HasOne(nr => nr.User)
                .WithMany()
                .HasForeignKey(nr => nr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Ticket)
                .WithMany(t => t.Notifications)
                .HasForeignKey(n => n.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
