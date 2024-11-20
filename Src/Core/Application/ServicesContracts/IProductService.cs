using Application.OrderAggregates;
using Application.ProductAggregates;
using Domain.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServicesContracts
{
    public interface IProductService
    {
        Task<ProductViewModel> GetProductAsync(int id);
        Task<List<ProductViewModel>> GetFragileProductAsync();
    }
}
