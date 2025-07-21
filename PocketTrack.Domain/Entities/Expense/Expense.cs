namespace PocketTrack.Domain.Entities.Expenses
{
    using PocketTrack.Domain.Entities.Expense.ValueObjects;
    using PocketTrack.Domain.Entities.ExpenseTypes;

    public class Expense
    {
        public int Id { get; set; }
        public required ExpenseDescription Description { get; set; } 
        public int ExpenseTypeId { get; set; }
        public required ExpenseAmount Amount { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateOnly SpentAt { get; set; }

        public ExpenseType? ExpenseType { get; set; }
    }
}
