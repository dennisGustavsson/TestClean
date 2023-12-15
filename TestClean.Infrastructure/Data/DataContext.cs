using Microsoft.EntityFrameworkCore;
using TestClean.Domain.Entities;

namespace TestClean.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<MeetingEntity> Meetings { get; set; }

        // ... other DbSet properties and configuration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships, indexes, etc.
        }
    }
}
