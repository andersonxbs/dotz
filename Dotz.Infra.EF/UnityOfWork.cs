using System.Threading.Tasks;
using Dotz.Domain.Contracts;
using Dotz.Infra.EF.Contexts;

namespace Dotz.Infra.EF
{
    public class UnityOfWork : IUnityOfWork
    {
        private SystemContext _context;

        public UnityOfWork(
            SystemContext context)
        {
            _context = context;
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
