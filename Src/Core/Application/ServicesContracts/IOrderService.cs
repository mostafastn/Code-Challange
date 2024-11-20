using Application.OrderAggregates;
using Domain.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServicesContracts
{
    public interface IOrderService
    {
        Task<OrderViewModel> CreateOrderAsync(OrderViewModel order);
    }
}
