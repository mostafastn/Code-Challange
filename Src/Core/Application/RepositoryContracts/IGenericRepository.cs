namespace Application.RepositoryContracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity, bool bypassSave = false);
        Task Delete(T entity, bool bypassSave = false);
        Task<T> Find(Func<T, bool> predicate);
        Task<T> FindAsync(int id);
        Task<IList<T>> GetAll();
        bool Any(Func<T, bool> predicate);
        Task<IList<T>> GetAll(Func<T, bool> predicate);
    }
}
