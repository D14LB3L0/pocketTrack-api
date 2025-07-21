namespace PocketTrack.Domain.Entities.Expenses
{
    using PocketTrack.Domain.Entities.ExpenseTypes;

    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ExpenseTypeId { get; set; }
        public decimal Amount { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ExpenseType? ExpenseType { get; set; }
    }
}
