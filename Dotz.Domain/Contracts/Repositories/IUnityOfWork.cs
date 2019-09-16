using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Repositories
{
    public interface IUnityOfWork
    {
        IUserRepository Users { get; }
        IAddressRepository Addresses { get; }
        IAccountRepository Accounts { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        Task CommitChangesAsync();
    }
}
