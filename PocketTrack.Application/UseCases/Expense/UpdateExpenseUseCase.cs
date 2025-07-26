using PocketTrack.Application.DTOs.Expense;
using PocketTrack.Application.Interfaces;
using PocketTrack.Domain.Entities.Expense.ValueObjects;
using PocketTrack.Domain.Interfaces;

namespace PocketTrack.Application.UseCases.Expense
{
    public class UpdateExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(UpdateExpenseDto updateExpenseDto)
        {
            var expense = await _expenseRepository.GetById(updateExpenseDto.Id);

            expense.Update(
                new ExpenseDescription(updateExpenseDto.Description),
                updateExpenseDto.ExpenseTypeId,
                new ExpenseAmount(updateExpenseDto.Amount),
                updateExpenseDto.SpentAt
            );

            _expenseRepository.Update(expense);

            await _unitOfWork.SaveChangesWithEventsAsync();
        }
    }
}
