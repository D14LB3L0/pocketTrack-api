using Microsoft.EntityFrameworkCore.Storage;
using PocketTrack.Application.Interfaces;

namespace PocketTrack.Infrastructure.Persistence
{
    public class EfCoreTransaction : ITransaction
    {
        private readonly IDbContextTransaction _efTransaction;

        public EfCoreTransaction(IDbContextTransaction efTransaction)
        {
            _efTransaction = efTransaction;
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
            => _efTransaction.CommitAsync(cancellationToken);

        public Task RollbackAsync(CancellationToken cancellationToken = default)
            => _efTransaction.RollbackAsync(cancellationToken);

        public ValueTask DisposeAsync()
            => _efTransaction.DisposeAsync();
    }
}
