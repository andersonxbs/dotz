using System.Threading.Tasks;

namespace Dotz.Domain.Contracts
{
    public interface IUnityOfWork
    {
        Task CommitChangesAsync();
    }
}
