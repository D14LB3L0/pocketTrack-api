using MediatR;

namespace PocketTrack.Domain.Events
{
    public interface IHasDomainEvents
    {
        public IReadOnlyCollection<INotification> DomainEvents { get; }
        void AddDomainEvent(INotification domainEvent);
        public void ClearDomainEvents();
    }
}
