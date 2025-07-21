using PocketTrack.Domain.Entities.ExpenseType.ValueObjects;

namespace PocketTrack.Domain.Entities.ExpenseTypes
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public required ExpenseTypeName Name { get; set; }
    }
}
