using PocketTrack.Domain.Entities.Expense;

namespace PocketTrack.Domain.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAllAsync();
        Task AddAsync(Expense expense);
    }
}
