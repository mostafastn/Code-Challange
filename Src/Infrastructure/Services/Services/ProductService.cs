using Application.OrderAggregates;
using Application.ProductAggregates;
using Application.RepositoryContracts;
using Application.ServicesContracts;
using Domain.OrderAggregates;
using Domain.ProductAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel> GetProductAsync(int id)
        {
            var product = await _productRepository.GetProductAsync(id);

            var productViewModel = (ProductViewModel)product;
            return productViewModel;

        }

        public async Task<List<ProductViewModel>> GetFragileProductAsync()
        {
            var products = await _productRepository.GetFragileProductAsync();

            var productViewModels = products.Select(t => (ProductViewModel)t).ToList();
            return productViewModels;
        }
    }
}
