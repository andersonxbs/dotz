using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities;
using Dotz.Infra.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace Dotz.Infra.EF.Repositories
{
    public class AddressRepository : RepositoryBase<Address, long>, IAddressRepository
    {
        public AddressRepository(SystemContext context) 
            : base(context)
        {
        }

        public async Task<Address> New(User user)
        {
            var address = new Address { User = user };

            await _context.Addresses.AddAsync(address);

            return address;
        }
    }
}
