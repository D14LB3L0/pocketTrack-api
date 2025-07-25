using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddExpense([FromBody] AddExpenseCommand command)
        {
           
            try
            {
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
