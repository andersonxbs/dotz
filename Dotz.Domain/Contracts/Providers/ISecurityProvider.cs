using Dotz.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Dotz.Domain.Contracts.Providers
{
    public interface ISecurityProvider
    {
        Task<(IdentityResult Result, User User, string Token)> Register(string name, string email, string password);
        Task<(SignInResult Result, User User, string Token)> Authenticate(string email, string password);
    }
}
