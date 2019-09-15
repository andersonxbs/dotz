﻿using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities;
using Dotz.Infra.EF.Contexts;
using Dotz.Infra.EF.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dotz.Infra.EF.Repositories
{
    public class AccountRepository : EntityBaseRepository<Account, long>, IAccountRepository
    {
        public AccountRepository(SystemContext context)
            : base(context)
        {
        }

        public async Task<Account> GetByUserIdAsync(string userId)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(d => d.User.Id == userId);
        }
    }
}
