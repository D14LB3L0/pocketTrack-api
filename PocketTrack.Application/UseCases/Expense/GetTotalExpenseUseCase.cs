using PocketTrack.Application.Interfaces;
using PocketTrack.Domain.Interfaces;

namespace PocketTrack.Application.UseCases.Expense
{
    public class GetTotalExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalExpenseUseCase(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<decimal> ExecuteAsync()
        {
            return await _expenseRepository.GetTotalExpensesAsync();
        }
    }
}
