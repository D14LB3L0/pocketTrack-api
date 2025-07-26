namespace PocketTrack.Application.DTOs.Expense
{
    public class UpdateExpenseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateOnly SpentAt { get; set; }
        public int ExpenseTypeId { get; set; }
    }
}
