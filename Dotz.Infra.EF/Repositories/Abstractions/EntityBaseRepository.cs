using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities.Abstractions;
using Dotz.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Infra.EF.Repositories.Abstractions
{
    public class EntityBaseRepository<TEntity, TKey> : 
        Repository<TEntity, TKey>, IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        public EntityBaseRepository(SystemContext context)
            : base(context)
        {
        }

        public sealed override async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>()
                .Where(d => !d.DeletedAt.HasValue)
                .ToListAsync();
        }

        
    }
}
