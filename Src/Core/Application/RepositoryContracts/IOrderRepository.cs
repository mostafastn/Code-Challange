using Domain.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryContracts
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
