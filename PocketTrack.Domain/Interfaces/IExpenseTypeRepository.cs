using PocketTrack.Domain.Entities.ExpenseType;

namespace PocketTrack.Domain.Interfaces
{
    public interface IExpenseTypeRepository
    {
        Task<List<ExpenseType>> GetAllAsync();
    }
}
