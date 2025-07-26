using Microsoft.EntityFrameworkCore;
using PocketTrack.Domain.Entities.Expense;
using PocketTrack.Domain.Interfaces;
using PocketTrack.Infrastructure.Mappers;

namespace PocketTrack.Infrastructure.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Expense expense)
        {
            var entity = ExpenseMapper.ToModel(expense);

            await _context.Expenses.AddAsync(entity);
        }

        public async Task<List<Expense>> GetAllAsync()
        {
            var entities = await _context.Expenses
                .Include(e => e.ExpenseType)
                .ToListAsync();

            return entities
                .Select(ExpenseMapper.ToDomain)
                .ToList();
        }
    }
}
