using MediatR;
using Microsoft.EntityFrameworkCore;
using PocketTrack.Infrastructure.Persistence.Configurations;

namespace PocketTrack.Infrastructure.Persistence
{
    using PocketTrack.Application.Interfaces;
    using PocketTrack.Domain.Events;

    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }
        public DbSet<Models.Expense> Expenses { get; set; }
        public DbSet<Models.ExpenseType> ExpenseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesWithEventsAsync(CancellationToken cancellationToken = default)
        {
            // Save changes to the database
            var result = await base.SaveChangesAsync(cancellationToken);

            // Get tracked entities that implement IHasDomainEvents and have pending events
            var domainEntities = ChangeTracker.Entries<IHasDomainEvents>()
                .Where(e => e.Entity.DomainEvents.Any())
                .ToList();

            // Extract all domain events from the entities
            var domainEvents = domainEntities
                .SelectMany(e => e.Entity.DomainEvents)
                .ToList();

            // Publish the domain events
            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent, cancellationToken);

            // Clear domain events after publishing
            foreach (var entity in domainEntities)
                entity.Entity.ClearDomainEvents();

            return result;
        }

        public async Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction = await Database.BeginTransactionAsync(cancellationToken);
            return new EfCoreTransaction(transaction);
        }

    }
}
