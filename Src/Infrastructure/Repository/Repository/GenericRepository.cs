using Application.RepositoryContracts;
using efdb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public virtual TEntity Add(TEntity entity)
        {
            return _tEntities.Add(entity).Entity;
        }
        public void Delete(TEntity entity)
        {
            _tEntities.Remove(entity);
        }
        public TEntity Find(Func<TEntity, bool> predicate)
        {
            return _tEntities.Where(predicate).FirstOrDefault();
        }
        public async Task<TEntity> FindAsync(int id)
        {

            return await _tEntities.FindAsync(id);
        }
        public IList<TEntity> GetAll()
        {

            return _tEntities.ToList();
        }
        public IQueryable<TEntity> GetAllAsyc()
        {
            return _tEntities.AsQueryable();
        }
        public IList<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return _tEntities.Where(predicate).ToList();
        }

        public bool Any(Func<TEntity, bool> predicate)
        {
            return _tEntities.Any(predicate);
        }

    }
}
