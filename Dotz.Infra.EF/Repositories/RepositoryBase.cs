using System.Threading.Tasks;
using Dotz.Domain.Contracts;
using Dotz.Infra.EF.Contexts;

namespace Dotz.Infra.EF.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity: class
    {
        protected readonly SystemContext _context;

        public RepositoryBase(SystemContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
