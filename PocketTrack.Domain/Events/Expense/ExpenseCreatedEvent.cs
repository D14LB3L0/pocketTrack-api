using MediatR;

namespace PocketTrack.Domain.Events.Expense
{
    using PocketTrack.Domain.Entities.Expense;
    public class ExpenseCreatedEvent : INotification
    {
        public Expense Expense { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public ExpenseCreatedEvent(Expense expense)
        {
            Expense = expense;
        }
    }
}
