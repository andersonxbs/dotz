using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities;
using Dotz.Infra.EF.Contexts;
using Dotz.Infra.EF.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Dotz.Infra.EF.Repositories
{
    public class AddressRepository : EntityBaseRepository<Address, long>, IAddressRepository
    {
        public AddressRepository(SystemContext context) 
            : base(context)
        {
        }

        public async Task<Address> NewAsync(User user)
        {
            var address = new Address { User = user };

            await _context.Addresses.AddAsync(address);

            return address;
        }

        public async Task<Address> GetByUserIdAsync(string userId)
        {
            return await _context.Addresses
                .FirstOrDefaultAsync(d => d.User.Id == userId);
        }
    }
}
