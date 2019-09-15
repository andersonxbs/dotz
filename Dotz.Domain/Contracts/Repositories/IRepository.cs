using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAsync();
    }
}
