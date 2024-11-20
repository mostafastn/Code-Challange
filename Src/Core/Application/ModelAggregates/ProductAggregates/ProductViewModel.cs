using Domain.OrderAggregates;
using Domain.ProductAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductAggregates
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsFragile { get; set; }

        /// <summary>
        /// Cast To ViewModel
        /// </summary>
        /// <param name="model"></param>
        public static explicit operator ProductViewModel(Product model)
        {
            if (model is null)
            {
                return null;
            }

            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                IsFragile = model.IsFragile
            };
        }
    }
}
