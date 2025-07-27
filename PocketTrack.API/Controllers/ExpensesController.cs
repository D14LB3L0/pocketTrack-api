using Microsoft.AspNetCore.Mvc;
using PocketTrack.API.Requests;
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
        private readonly UpdateExpenseUseCase _updateExpenseUseCase;
        private readonly DeleteExpenseUseCase _deleteExpenseUseCase;

        public ExpensesController(AddExpenseUseCase addExpenseUseCase, GetAllExpenseUseCase getAllExpenseUseCase, UpdateExpenseUseCase updateExpenseUseCase, DeleteExpenseUseCase deleteExpenseUseCase)
        {
            _addExpenseUseCase = addExpenseUseCase;
            _getAllExpenseUseCase = getAllExpenseUseCase;
            _updateExpenseUseCase = updateExpenseUseCase;
            _deleteExpenseUseCase = deleteExpenseUseCase;
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
        public async Task<IActionResult> AddExpense([FromBody] AddExpenseRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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

        [HttpPut]
        public async Task<IActionResult> UpdateExpense([FromBody] UpdateExpenseRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var expenseDto = new UpdateExpenseDto
                {
                    Id = request.Id!.Value,
                    Description = request.Description!,
                    Amount = request.Amount!.Value,
                    SpentAt = request.SpentAt!.Value,
                    ExpenseTypeId = request.ExpenseTypeId!.Value,
                };

                await _updateExpenseUseCase.ExecuteAsync(expenseDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            try
            {
                await _deleteExpenseUseCase.ExecuteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
