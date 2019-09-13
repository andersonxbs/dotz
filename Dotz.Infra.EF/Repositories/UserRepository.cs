using Dotz.Domain.Contracts;
using Dotz.Domain.Entities;
using Dotz.Infra.EF.Contexts;

namespace Dotz.Infra.EF.Repositories
{
    public class UserRepository : RepositoryBase<User, string>, IUserRepository
    {
        public UserRepository(SystemContext context)
            : base(context)
        { }
    }
}
