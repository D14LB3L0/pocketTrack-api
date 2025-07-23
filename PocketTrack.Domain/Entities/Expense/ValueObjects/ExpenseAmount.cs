namespace PocketTrack.Domain.Entities.Expense.ValueObjects
{
    public class ExpenseAmount
    {
        public decimal Value { get; }

        public ExpenseAmount(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("The amount cannot be negative.");

            if (decimal.Round(value, 2) != value)
                throw new ArgumentException("The amount must have a maximum of two decimal places.");

            Value = value;
        }

        public override string ToString() => Value.ToString("F2");
    }
}
