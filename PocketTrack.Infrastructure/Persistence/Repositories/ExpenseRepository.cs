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

        public async Task<Expense> GetById(int id)
        {
            var entity = await _context.Expenses.FindAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"Expense with {id} not found");

            return ExpenseMapper.ToDomain(entity);
        }

        public void Update(Expense expense)
        {
            var entity = ExpenseMapper.ToModel(expense);

            var local = _context.Expenses.Local.FirstOrDefault(e => e.Id == entity.Id);
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Expenses.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);

            if (expense == null)
                throw new KeyNotFoundException($"Expense with {id} not found");

            expense.IsDeleted = true;
            expense.UpdatedAt = DateTime.UtcNow;
        }
    }
}
