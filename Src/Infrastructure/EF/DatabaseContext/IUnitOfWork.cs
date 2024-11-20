using Microsoft.EntityFrameworkCore;

namespace EF.DatabaseContext
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
