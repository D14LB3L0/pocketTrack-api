using PocketTrack.Domain.Enums;

namespace PocketTrack.Domain.Entities.ExpenseType.ValueObjects
{
    public class ExpenseTypeName
    {
        public ExpenseCategory Value { get; }

        public ExpenseTypeName(string name)
        {
            if (!Enum.TryParse<ExpenseCategory>(name, ignoreCase: true, out var parsed))
                throw new ArgumentException($"Invalid expense category name: {name}");

            Value = parsed;
        }

        public ExpenseTypeName(ExpenseCategory category)
        {
            Value = category;
        }

        public override string ToString() => Value.ToString();

        public override bool Equals(object? obj)
        {
            if (obj is ExpenseTypeName other)
                return Value == other.Value;

            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}
