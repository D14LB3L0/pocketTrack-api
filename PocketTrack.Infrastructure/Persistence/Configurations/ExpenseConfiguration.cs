using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketTrack.Infrastructure.Persistence.Models;

namespace PocketTrack.Infrastructure.Persistence.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("expenses");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(e => e.Amount)
                   .HasPrecision(18, 2);

            builder.Property(e => e.IsDeleted);

            builder.Property(e => e.CreatedAt);
            builder.Property(e => e.UpdatedAt);

            builder.HasOne(e => e.ExpenseType)
                   .WithMany(et => et.Expenses)
                   .HasForeignKey(e => e.ExpenseTypeId);
        }
    }
}
