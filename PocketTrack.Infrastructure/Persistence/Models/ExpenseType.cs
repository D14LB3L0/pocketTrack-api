namespace PocketTrack.Infrastructure.Persistence.Models;

public partial class ExpenseType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
