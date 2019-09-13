using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IUnityOfWork
    {
        IUserRepository Users { get; }
        IAddressRepository Addresses { get; }
        Task CommitChangesAsync();
    }
}
