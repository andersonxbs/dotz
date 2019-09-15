using Dotz.Domain.Entities;
using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IAddressRepository : IRepository<Address, long>
    {
        Task<Address> New(User user);

        Task<Address> GetByUserIdAsync(string userId);
    }
}
