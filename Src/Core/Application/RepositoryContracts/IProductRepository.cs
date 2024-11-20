using Application.ProductAggregates;
using Domain.OrderAggregates;
using Domain.ProductAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryContracts
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(int id);
        Task<ICollection<Product>> GetFragileProductAsync();
    }
}
