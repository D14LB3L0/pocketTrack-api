using PocketTrack.Domain.Entities.Expenses;

namespace PocketTrack.Infrastructure.Mappers
{
    public static class ExpenseMapper
    {
        public static Expense ToDomain(Persistence.Models.Expense model)
        {
            return new Expense
            {
                Id = model.Id,
                Description = model.Description,
                Amount = model.Amount,
                ExpenseTypeId = model.ExpenseTypeId,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                IsDeleted = model.IsDeleted,
                ExpenseType = model.ExpenseType != null
                    ? ExpenseTypeMapper.ToDomain(model.ExpenseType)
                    : null
            };
        }

        public static Persistence.Models.Expense ToModel(Expense entity)
        {
            return new Persistence.Models.Expense
            {
                Id = entity.Id,
                Description = entity.Description,
                Amount = entity.Amount,
                ExpenseTypeId = entity.ExpenseTypeId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsDeleted = entity.IsDeleted
            };
        }
    }
}
