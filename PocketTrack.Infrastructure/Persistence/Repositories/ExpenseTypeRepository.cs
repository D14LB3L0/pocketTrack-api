using Microsoft.EntityFrameworkCore;
using PocketTrack.Domain.Entities.ExpenseTypes;
using PocketTrack.Domain.Interfaces;
using PocketTrack.Infrastructure.Mappers;

namespace PocketTrack.Infrastructure.Persistence.Repositories
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpenseType>> GetAllAsync()
        {
            var entities = await _context.ExpenseTypes.ToListAsync();
            return entities
                .Select(ExpenseTypeMapper.ToDomain)
                .ToList();
        }
    }
}
