using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketTrack.Infrastructure.Persistence.Models;

namespace PocketTrack.Infrastructure.Persistence.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.ToTable("expenses");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(e => e.Amount)
                   .HasPrecision(18, 2);

            builder.Property(e => e.IsDeleted)
                   .HasColumnName("is_deleted");

            builder.Property(e => e.CreatedAt)
                   .HasColumnName("created_at");

            builder.Property(e => e.UpdatedAt)
                   .HasColumnName("updated_at");
            
            builder.Property(e => e.SpentAt)
                   .HasColumnName("spent_at");

            builder.Property(e => e.ExpenseTypeId)
                   .HasColumnName("expense_type_id");

            builder.HasOne(e => e.ExpenseType)
                   .WithMany(et => et.Expenses)
                   .HasForeignKey(e => e.ExpenseTypeId);

            builder.Ignore(e => e.DomainEvents);

        }
    }
}
