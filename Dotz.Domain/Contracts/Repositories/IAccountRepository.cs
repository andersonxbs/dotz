using Dotz.Domain.Entities;
using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IAccountRepository : IRepository<Account, long>
    {
        Task<Account> GetByUserIdAsync(string userId);

        Task<Account> NewAsync(string userId);
    }
}
