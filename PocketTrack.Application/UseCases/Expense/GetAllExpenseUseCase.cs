using PocketTrack.Application.DTOs.Expense;
using PocketTrack.Domain.Interfaces;

namespace PocketTrack.Application.UseCases.Expense
{
    public class GetAllExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;

        public GetAllExpenseUseCase(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<List<ExpenseDto>> ExecuteAsync()
        {
            var expense = await _expenseRepository.GetAllAsync();
            return expense.Select(e => new ExpenseDto
            {
                Id = e.Id,
                Description = e.Description.Value,
                Amount = e.Amount.Value,
                SpentAt = e.SpentAt,
                ExpenseType = new DTOs.ExpenseType.ExpenseTypeDto
                {
                    Id = e.ExpenseType!.Id,
                    Name = e.ExpenseType.Name
                }
            }).ToList();
        }
    }
}
