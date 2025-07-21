namespace PocketTrack.Domain.Entities.ExpenseTypes
{
    using PocketTrack.Domain.Entities.Expenses;

    public class ExpenseType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Expense>? Expenses { get; set; }
    }
}
