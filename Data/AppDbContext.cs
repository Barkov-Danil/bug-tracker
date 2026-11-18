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
    }
}
