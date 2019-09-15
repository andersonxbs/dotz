using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities.Abstractions;
using Dotz.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Infra.EF.Repositories.Abstractions
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity: class
    {
        protected readonly SystemContext _context;

        public Repository(SystemContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>()
                .ToListAsync();
        }
    }
}
