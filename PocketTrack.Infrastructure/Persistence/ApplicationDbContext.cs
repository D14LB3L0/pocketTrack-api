using Microsoft.EntityFrameworkCore;
using PocketTrack.Infrastructure.Persistence.Configurations;
using PocketTrack.Infrastructure.Persistence.Models;

namespace PocketTrack.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
