using PocketTrack.Domain.Entities.Expense;

namespace PocketTrack.Domain.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense> GetById(int id);
        Task<List<Expense>> GetAllAsync();
        Task AddAsync(Expense expense);
        void Update(Expense expense);
        Task DeleteAsync(int id);
    }
}
