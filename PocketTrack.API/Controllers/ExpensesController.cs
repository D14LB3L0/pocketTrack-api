using Microsoft.AspNetCore.Mvc;
using PocketTrack.Application.DTOs.Expense;
using PocketTrack.Application.UseCases.Expense;
using PocketTrack.Application.UseCases.Expense.Command;
using PocketTrack.Services.API;

namespace PocketTrack.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpensesController : BaseController
    {
        private readonly AddExpenseUseCase _addExpenseUseCase;
        private readonly GetAllExpenseUseCase _getAllExpenseUseCase;

        public ExpensesController(AddExpenseUseCase addExpenseUseCase, GetAllExpenseUseCase getAllExpenseUseCase)
        {
            _addExpenseUseCase = addExpenseUseCase;
            _getAllExpenseUseCase = getAllExpenseUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _getAllExpenseUseCase.ExecuteAsync();

                return Ok(Result<List<ExpenseDto>>.Ok(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
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
