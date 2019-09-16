using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Dotz.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public virtual Address Address { get; set; }
        public virtual Account Account { get; set; } = new Account();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
