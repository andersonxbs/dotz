﻿using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities;
using Dotz.Infra.EF.Contexts;
using Dotz.Infra.EF.Repositories.Abstractions;

namespace Dotz.Infra.EF.Repositories
{
    public class UserRepository : Repository<User, string>, IUserRepository
    {
        public UserRepository(SystemContext context)
           : base(context)
        {
        }
    }
}
