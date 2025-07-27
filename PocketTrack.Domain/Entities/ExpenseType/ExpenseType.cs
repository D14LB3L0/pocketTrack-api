﻿
namespace PocketTrack.Domain.Entities.ExpenseType
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
