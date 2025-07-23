using Microsoft.AspNetCore.Mvc;
using PocketTrack.API.Requests.Expense;
using PocketTrack.Application.UseCases.Expense;
using PocketTrack.Application.UseCases.Expense.Command;

namespace PocketTrack.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpensesController : BaseController
    {
        private readonly AddExpenseUseCase _addExpenseUseCase;

        public ExpensesController(AddExpenseUseCase addExpenseUseCase)
        {
            _addExpenseUseCase = addExpenseUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] AddExpenseRequest request)
        {
           
            try
            {
                var command = new AddExpenseCommand
                {
                    Description = request.Description!,
                    Amount = request.Amount!.Value,
                    ExpenseTypeId = request.ExpenseTypeId!.Value,
                    SpentAt = request.SpentAt!.Value
                };

                await _addExpenseUseCase.ExecuteAsync(command);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
