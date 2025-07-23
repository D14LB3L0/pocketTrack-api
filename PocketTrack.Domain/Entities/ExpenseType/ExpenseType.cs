using PocketTrack.Domain.Entities.ExpenseType.ValueObjects;

namespace PocketTrack.Domain.Entities.ExpenseType
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public required ExpenseTypeName Name { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
