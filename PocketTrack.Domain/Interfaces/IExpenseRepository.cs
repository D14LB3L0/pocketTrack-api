using PocketTrack.Domain.Entities.Expense;

namespace PocketTrack.Domain.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expense);
    }
}
