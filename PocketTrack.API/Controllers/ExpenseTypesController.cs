using Microsoft.AspNetCore.Mvc;
using PocketTrack.Application.DTOs.ExpenseType;
using PocketTrack.Application.UseCases.ExpenseType;
using PocketTrack.Services.API;

namespace PocketTrack.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpenseTypesController : BaseController
    {
        private readonly GetAllExpenseTypesUseCase _useCase;

        public ExpenseTypesController(GetAllExpenseTypesUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _useCase.ExecuteAsync();

                return Ok(Result<List<ExpenseTypeDto>>.Ok(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
