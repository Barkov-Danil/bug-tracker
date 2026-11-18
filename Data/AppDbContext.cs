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

            modelBuilder.Entity<Fix>()
                .HasOne(f => f.Author)
                .WithMany(u => u.FixesWhereAuthor)
                .HasForeignKey(f => f.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fix>()
                .HasOne(f => f.Assignee)
                .WithMany(u => u.FixesWhereAssignee)
                .HasForeignKey(f => f.TesterId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
