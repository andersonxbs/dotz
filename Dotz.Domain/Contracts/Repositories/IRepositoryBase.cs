using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity, TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
    }
}
