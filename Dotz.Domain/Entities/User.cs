using Microsoft.AspNetCore.Identity;

namespace Dotz.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
