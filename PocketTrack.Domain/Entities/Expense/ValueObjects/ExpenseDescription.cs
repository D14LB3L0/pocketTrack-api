namespace PocketTrack.Domain.Entities.Expense.ValueObjects
{
    public class ExpenseDescription
    {
        public string Value { get; }

        public ExpenseDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("The description cannot be empty.");

            if (value.Length > 50)
                throw new ArgumentException("The description cannot exceed 50 characters.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}
