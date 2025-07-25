using PocketTrack.Domain.Entities.ExpenseType;

namespace PocketTrack.Infrastructure.Mappers
{
    public class ExpenseTypeMapper
    {
        public static ExpenseType ToDomain(Persistence.Models.ExpenseType model)
        {
            return new ExpenseType
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static Persistence.Models.ExpenseType ToModel(ExpenseType entity)
        {
            return new Persistence.Models.ExpenseType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
