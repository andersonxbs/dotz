using System.Threading.Tasks;

namespace Dotz.Domain.Contracts
{
    public interface IUnityOfWork
    {
        IUserRepository Users { get; }

        Task CommitChangesAsync();
    }
}
