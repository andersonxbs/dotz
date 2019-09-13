using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Dotz.Domain.Contracts
{
    public interface ISecurityProvider
    {
        Task<(IdentityResult Result, IdentityUser User, string Token)> Register(string email, string password);
        Task<(SignInResult Result, IdentityUser User, string Token)> Authenticate(string email, string password);
    }
}
