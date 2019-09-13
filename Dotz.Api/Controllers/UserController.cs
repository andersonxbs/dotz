using Dotz.Api.Models.User;
using Dotz.Domain.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ISecurityProvider _securityProvider;

        public UserController(ISecurityProvider securityProvider)
        {
            _securityProvider = securityProvider;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(d => d.Errors));

            var registerInfo = await _securityProvider.Register(registerModel.Email, registerModel.Password);

            if (!registerInfo.Result.Succeeded)
                return BadRequest(registerInfo.Result.Errors);

            return Created(
                "me", 
                new AuthResultModel
                {
                    User = new UserModel
                    {
                        Id = registerInfo.User.Id,
                        Email = registerInfo.User.Email
                    },
                    Token = registerInfo.Token
                });
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticateModel authModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(d => d.Errors));

            var authInfo = await _securityProvider.Authenticate(authModel.Email, authModel.Password);

            if (!authInfo.Result.Succeeded)
                return BadRequest("Invalid password or email");

            return Ok(new AuthResultModel
            {
                User = new UserModel
                {
                    Id = authInfo.User.Id,
                    Email = authInfo.User.Email
                },
                Token = authInfo.Token
            });
        }

        [HttpGet("me")]
        public async Task<ActionResult> Me()
        {
            var currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return Ok(new { ok = true });
        }
    }
}
