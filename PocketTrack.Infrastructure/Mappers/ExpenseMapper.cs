using PocketTrack.Domain.Entities.Expense.ValueObjects;
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
                Description = new ExpenseDescription(model.Description),
                Amount = new ExpenseAmount(model.Amount),
                ExpenseTypeId = model.ExpenseTypeId,
                SpentAt = model.SpentAt,
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
                Description = entity.Description.Value,
                Amount = entity.Amount.Value,
                ExpenseTypeId = entity.ExpenseTypeId,
                SpentAt = entity.SpentAt,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsDeleted = entity.IsDeleted
            };
        }
    }
}
