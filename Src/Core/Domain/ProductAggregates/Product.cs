using Domain.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductAggregates
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsFragile { get; set; }

        public virtual OrderItem OrderItem { get; set; }
    }
}
