using Dotz.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dotz.Infra.EF.Contexts
{
    public partial class SystemContext : IdentityDbContext<User>
    {
        public SystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
