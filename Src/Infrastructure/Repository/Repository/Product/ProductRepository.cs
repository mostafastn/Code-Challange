using Application.RepositoryContracts;
using Domain.ProductAggregates;
using efdb;
using Microsoft.EntityFrameworkCore;

namespace Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        protected IUnitOfWork _uow;
        protected DbSet<Product> _tEntities;
        public ProductRepository(IUnitOfWork uow)
        {
            _uow = uow;
            _tEntities = _uow.Set<Product>();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _tEntities.FindAsync(id);
            if (product == null)
            {
                throw new Exception($"Product with ID {id} not found.");
            }
            return product;
        }

        public async Task<ICollection<Product>> GetFragileProductAsync()
        {
            var product = await _tEntities.Where(t => t.IsFragile).ToListAsync();
            return product;
        }
    }
}
