using Application.RepositoryContracts;
using efdb;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected IUnitOfWork _uow;
        protected DbSet<TEntity> _tEntities;
        public GenericRepository(IUnitOfWork uow)
        {
            _uow = uow;
            _tEntities = _uow.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity, bool bypassSave = false)
        {
            await _tEntities.AddAsync(entity);
            if (!bypassSave)
                await _uow.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(TEntity entity, bool bypassSave = false)
        {
            _tEntities.Remove(entity);
            if (!bypassSave)
                await _uow.SaveChangesAsync();
        }

        public async Task<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return await _tEntities.Where(predicate: predicate).AsQueryable().FirstOrDefaultAsync();
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _tEntities.FindAsync(id);
        }

        public bool Any(Func<TEntity, bool> predicate)
        {
            return _tEntities.Any(predicate);
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _tEntities.ToListAsync();
        }

        public async Task<IList<TEntity>> GetAll(Func<TEntity, bool> predicate)
        {
            return await _tEntities.Where(predicate).AsQueryable().ToListAsync();
        }
    }
}
