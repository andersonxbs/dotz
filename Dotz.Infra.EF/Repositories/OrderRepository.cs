using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities;
using Dotz.Infra.EF.Contexts;
using Dotz.Infra.EF.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Infra.EF.Repositories
{
    public class OrderRepository : EntityBaseRepository<Order, long>, IOrderRepository
    {
        public OrderRepository(SystemContext context) 
            : base(context)
        {
        }

        public async Task<Order> NewAsync(User user)
        {
            var order = new Order { User = user };

            await _context.Orders.AddAsync(order);

            return order;
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId)
        {
            return await _context.Orders
                .Where(d => d.User.Id == userId)
                .ToListAsync();
        }
    }
}
