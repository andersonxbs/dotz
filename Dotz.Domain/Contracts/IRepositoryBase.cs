using System.Threading.Tasks;

namespace Dotz.Domain.Contracts
{
    public interface IRepositoryBase<TEntity, TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
    }
}
