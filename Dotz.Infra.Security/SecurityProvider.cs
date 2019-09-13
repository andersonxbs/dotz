using Dotz.Domain.Contracts;
using Dotz.Domain.Entities;
using Dotz.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infra.Security
{
    public class SecurityProvider : ISecurityProvider
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JWTSettings _jwtSettings;

        public SecurityProvider(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IOptions<JWTSettings> jwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<(IdentityResult Result, User User, string Token)> Register(
            string name,
            string email, 
            string password)
        {
            var user = new User
            {
                UserName = email,
                Email = email,
                Name = name
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return (result, null, null);

            await _signInManager.SignInAsync(user, false);

            return (result, user, GenerateJwtToken(user));
        }

        public async Task<(SignInResult Result, User User, string Token)> Authenticate(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var result = await _signInManager.PasswordSignInAsync(
                user,
                password,
                isPersistent: false,
                lockoutOnFailure: false);

            if (!result.Succeeded)
                return (result, null, null);

            return (result, user, GenerateJwtToken(user));         
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var identityClaims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _jwtSettings.ValidIssuer,
                Audience = _jwtSettings.ValidAudience,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiresInHours),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
