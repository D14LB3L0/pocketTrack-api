namespace PocketTrack.Application.UseCases.Expense.Command
{
    public class AddExpenseCommand
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int ExpenseTypeId { get; set; }
        public DateTime SpentAt { get; set; }
    }
}
