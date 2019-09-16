using Dotz.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IProductRepository : IRepository<Product, long>
    {
        Task<IEnumerable<Product>> GetAsync(long[] ids);
    }
}
