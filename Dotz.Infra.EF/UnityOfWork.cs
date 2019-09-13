using System.Threading.Tasks;
using Dotz.Domain.Contracts;
using Dotz.Infra.EF.Contexts;
using Dotz.Infra.EF.Repositories;

namespace Dotz.Infra.EF
{
    public class UnityOfWork : IUnityOfWork
    {
        private SystemContext _context;

        private IUserRepository _userRepository;

        public UnityOfWork(
            SystemContext context)
        {
            _context = context;
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
