using Dotz.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IOrderRepository : IRepository<Order, long>
    {
        Task<Order> NewAsync(User user);

        Task<IEnumerable<Order>> GetByUserIdAsync(string userId);
    }
}
