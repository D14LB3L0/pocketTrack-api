using PocketTrack.Domain.Interfaces;

namespace PocketTrack.Application.UseCases.Expense
{
    using PocketTrack.Application.UseCases.Expense.Command;
    using PocketTrack.Domain.Entities.Expense.ValueObjects;
    using PocketTrack.Domain.Entities.Expense;
    using PocketTrack.Application.Interfaces;

    public class AddExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(AddExpenseCommand command)
        {
            var expense = new Expense(
                new ExpenseDescription(command.Description),
                command.ExpenseTypeId,
                new ExpenseAmount(command.Amount),
                DateOnly.FromDateTime(command.SpentAt)
            );

            await _expenseRepository.AddAsync(expense);

            await _unitOfWork.SaveChangesWithEventsAsync();
        }
    }
}
