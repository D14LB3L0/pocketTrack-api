using PocketTrack.Domain.Entities.ExpenseType.ValueObjects;
using PocketTrack.Domain.Entities.ExpenseTypes;

namespace PocketTrack.Infrastructure.Mappers
{
    public class ExpenseTypeMapper
    {
        public static ExpenseType ToDomain(Persistence.Models.ExpenseType model)
        {
            return new ExpenseType
            {
                Id = model.Id,
                Name = new ExpenseTypeName(model.Name),
            };
        }

        public static Persistence.Models.ExpenseType ToModel(ExpenseType entity)
        {
            return new Persistence.Models.ExpenseType
            {
                Id = entity.Id,
                Name = entity.Name.Value.ToString()
            };
        }
    }
}
