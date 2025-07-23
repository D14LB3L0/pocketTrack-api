namespace PocketTrack.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesWithEventsAsync(CancellationToken cancellationToken = default);
        Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    }
}
