using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketTrack.Infrastructure.Persistence.Models;

namespace PocketTrack.Infrastructure.Persistence.Configurations
{
    public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.HasQueryFilter(e => e.IsActive == true);

            builder.ToTable("expense_types");

            builder.HasKey(et => et.Id);

            builder.Property(et => et.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.CreatedAt)
                   .HasColumnName("created_at");
            
            builder.Property(e => e.IsActive)
                   .HasColumnName("is_active");
        }
    }
}
