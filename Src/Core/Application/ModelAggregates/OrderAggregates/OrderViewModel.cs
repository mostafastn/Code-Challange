using Domain.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderAggregates
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
        public decimal TotalPrice => OrderItems.Sum(item => item.Subtotal);
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsFragile => OrderItems.Any(item => item.Product.IsFragile);
        public string ShippingMethod { get; set; }


        /// <summary>
        /// Cast To Entity
        /// </summary>
        /// <param name="model"></param>
        public static explicit operator Order(OrderViewModel model)
        {
            if (model is null)
            {
                return null;
            }

            return new Order()
            {
                Id = model.OrderId,
                CreatedAt = model.CreatedAt,
                ShippingMethod = model.ShippingMethod,
                CustomerId = model.CustomerId,
                Discount = model.Discount,
                IsFragile = model.IsFragile,
                TotalPrice = model.TotalPrice,                
            };
        }

    }
}
