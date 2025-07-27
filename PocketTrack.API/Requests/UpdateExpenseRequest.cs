using System.ComponentModel.DataAnnotations;

namespace PocketTrack.API.Requests
{
    public class UpdateExpenseRequest
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        [Required]
        public int? ExpenseTypeId { get; set; }
        [Required]
        public DateOnly? SpentAt { get; set; }
    }
}
