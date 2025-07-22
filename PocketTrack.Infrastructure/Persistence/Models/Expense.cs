namespace PocketTrack.Infrastructure.Persistence.Models;

public partial class Expense
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int ExpenseTypeId { get; set; }

    public decimal Amount { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateOnly SpentAt { get; set; }

    public virtual ExpenseType ExpenseType { get; set; } = null!;
}
