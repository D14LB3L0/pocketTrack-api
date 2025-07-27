using PocketTrack.Application.DTOs.ExpenseType;

namespace PocketTrack.Application.DTOs.Expense
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateOnly SpentAt { get; set; }

        public required ExpenseTypeDto ExpenseType { get; set; }
    }
}
