using MediatR;
using PocketTrack.Domain.Events.Expense;

namespace PocketTrack.Application.Events.Expenses
{
    public class ExpenseCreatedHandler : INotificationHandler<ExpenseCreatedEvent>
    {
        public Task Handle(ExpenseCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"🟢 Evento: Gasto creado con ID {notification.Expense.Id} en {notification.OccurredOn}");

            return Task.CompletedTask;
        }
    }
}
