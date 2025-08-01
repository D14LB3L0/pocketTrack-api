﻿using MediatR;
using PocketTrack.Domain.Events;

namespace PocketTrack.Infrastructure.Persistence.Models
{
    public partial class Expense : IHasDomainEvents
    {
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
    }
}
