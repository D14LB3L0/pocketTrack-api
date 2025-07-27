using PocketTrack.Application.DTOs.ExpenseType;
using PocketTrack.Domain.Interfaces;

namespace PocketTrack.Application.UseCases.ExpenseType
{
    public class GetAllExpenseTypesUseCase
    {
        private readonly IExpenseTypeRepository _expenseTypeRepository;

        public GetAllExpenseTypesUseCase(IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseTypeRepository = expenseTypeRepository;
        }

        public async Task<List<ExpenseTypeDto>> ExecuteAsync()
        {
            var expenseTypes = await _expenseTypeRepository.GetAllAsync();
            return expenseTypes.Select(et => new ExpenseTypeDto
            {
                Id = et.Id,
                Name = et.Name.ToString(),
            }).ToList();
        }
    }
}
