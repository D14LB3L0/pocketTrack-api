using PocketTrack.Domain.Interfaces;

namespace PocketTrack.Application.UseCases.Expense
{
    using PocketTrack.Application.UseCases.Expense.Command;
    using PocketTrack.Domain.Entities.Expense.ValueObjects;
    using PocketTrack.Domain.Entities.Expense;
    using PocketTrack.Application.Interfaces;
    using MediatR;

    public class AddExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public AddExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
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
