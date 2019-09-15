using Dotz.Domain.Entities;
using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByUserIdAsync(string userId);
    }
}
