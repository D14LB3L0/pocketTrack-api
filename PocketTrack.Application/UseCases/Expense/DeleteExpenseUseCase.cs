using PocketTrack.Application.Interfaces;
using PocketTrack.Domain.Interfaces;

namespace PocketTrack.Application.UseCases.Expense
{
    public class DeleteExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(int id)
        {
            await _expenseRepository.DeleteAsync(id);

            await _unitOfWork.SaveChangesWithEventsAsync();
        }
    }
}
