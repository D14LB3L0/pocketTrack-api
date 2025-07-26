namespace PocketTrack.Domain.Entities.Expense
{
    using MediatR;
    using PocketTrack.Domain.Entities.Expense.ValueObjects;
    using PocketTrack.Domain.Entities.ExpenseType;
    using PocketTrack.Domain.Events;
    using PocketTrack.Domain.Events.Expense;

    public class Expense : IHasDomainEvents
    {
        public int Id { get; set; }
        public ExpenseDescription Description { get; set; } 
        public int ExpenseTypeId { get; set; }
        public ExpenseAmount Amount { get; set; }
        public DateOnly SpentAt { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Connection Reference
        public ExpenseType? ExpenseType { get; set; }

        // Events
        private readonly List<INotification> _domainEvents = new();
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public Expense(
            ExpenseDescription description,
            int expenseTypeId,
            ExpenseAmount amount,
            DateOnly spentAt)
        {
            Description = description;
            ExpenseTypeId = expenseTypeId;
            Amount = amount;
            SpentAt = spentAt;

            AddDomainEvent(new ExpenseCreatedEvent(this));
        }

        public void Update(ExpenseDescription description, int expenseTypeId, ExpenseAmount amount, DateOnly spentAt)
        {
            Description = description;
            ExpenseTypeId = expenseTypeId;
            Amount = amount;
            SpentAt = spentAt;
        }

        public Expense() { }
    }
}
