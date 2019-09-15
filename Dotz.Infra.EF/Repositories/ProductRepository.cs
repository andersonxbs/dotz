using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities;
using Dotz.Infra.EF.Contexts;
using Dotz.Infra.EF.Repositories.Abstractions;

namespace Dotz.Infra.EF.Repositories
{
    public class ProductRepository : EntityBaseRepository<Product, long>, IProductRepository
    {
        public ProductRepository(SystemContext context)
           : base(context)
        {
        }
    }
}
