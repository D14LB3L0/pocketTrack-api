using System.ComponentModel.DataAnnotations;

namespace PocketTrack.API.Requests
{
    public class AddExpenseRequest
    {
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        [Required]
        public int? ExpenseTypeId { get; set; }
        [Required]
        public DateTime? SpentAt { get; set; }
    }
}
