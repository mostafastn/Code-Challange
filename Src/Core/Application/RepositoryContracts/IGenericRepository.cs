using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryContracts
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T entity);
        void Delete(T entity);
        T Find(Func<T, bool> predicate);
        Task<T> FindAsync(int id);
        IList<T> GetAll();
        bool Any(Func<T, bool> predicate);
        IList<T> GetAll(Func<T, bool> predicate);
        IQueryable<T> GetAllAsyc();
    }
}
