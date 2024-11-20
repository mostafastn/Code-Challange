using Application.RepositoryContracts;
using Domain.OrderAggregates;
using EF.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Orders
{
    public class OrderRepository : IOrderRepository
    {
        protected IUnitOfWork _uow;
        protected DbSet<Order> _tEntities;
        public OrderRepository(IUnitOfWork uow)
        {
            _uow = uow;
            _tEntities = _uow.Set<Order>();
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _tEntities.AddAsync(order);
            await _uow.SaveChangesAsync();
            return order;
        }
    }
}
