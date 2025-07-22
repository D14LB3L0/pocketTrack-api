using PocketTrack.Domain.Entities.ExpenseTypes;

namespace PocketTrack.Domain.Interfaces
{
    public interface IExpenseTypeRepository
    {
        Task<List<ExpenseType>> GetAllAsync();
    }
}
