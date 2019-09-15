using Microsoft.AspNetCore.Identity;

namespace Dotz.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public virtual Address Address { get; set; }
        public virtual Account Account { get; set; } = new Account();
    }
}
