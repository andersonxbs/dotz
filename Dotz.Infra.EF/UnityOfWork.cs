using Dotz.Domain.Contracts.Repositories;
using Dotz.Infra.EF.Contexts;
using Dotz.Infra.EF.Repositories;
using System.Threading.Tasks;

namespace Dotz.Infra.EF
{
    public class UnityOfWork : IUnityOfWork
    {
        private SystemContext _context;

        private IUserRepository _userRepository;
        private IAddressRepository _addressRepository;
        private IAccountRepository _accountRepository;

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

        public IAddressRepository Addresses
        {
            get
            {
                if (_addressRepository == null)
                    _addressRepository = new AddressRepository(_context);

                return _addressRepository;
            }
        }

        public IAccountRepository Accounts
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_context);

                return _accountRepository;
            }
}

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
