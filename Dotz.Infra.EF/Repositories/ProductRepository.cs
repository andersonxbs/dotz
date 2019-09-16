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
    public class ProductRepository : EntityBaseRepository<Product, long>, IProductRepository
    {
        public ProductRepository(SystemContext context)
           : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAsync(long[] ids)
        {
            return await _context.Products
                .Where(d => ids.Contains(d.Id))
                .ToListAsync();
        }
    }
}
