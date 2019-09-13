using AutoMapper;
using Dotz.Api.Models.User;
using Dotz.Domain.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ISecurityProvider _securityProvider;
        private readonly IUnityOfWork _repositories;
        private readonly IMapper _mapper;

        public UserController(
            ISecurityProvider securityProvider,
            IUnityOfWork repositories,
            IMapper mapper)
        {
            _securityProvider = securityProvider;
            _repositories = repositories;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(d => d.Errors));

            var registerInfo = await _securityProvider.Register(
                registerModel.Name, 
                registerModel.Email, 
                registerModel.Password);

            if (!registerInfo.Result.Succeeded)
                return BadRequest(registerInfo.Result.Errors.Where(d => !d.Code.Equals("DuplicateUserName")));

            return Created(
                "me", 
                new AuthResultModel
                {
                    User = _mapper.Map<UserModel>(registerInfo.User),
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
                return BadRequest(new IdentityError { Code = "InvalidCredentials", Description = "Invalid email or password." });

            return Ok(new AuthResultModel
            {
                User = _mapper.Map<UserModel>(authInfo.User),
                Token = authInfo.Token
            });
        }

        [HttpGet("me")]
        public async Task<ActionResult> Me()
        {
            var user = await _repositories.Users.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return Ok(_mapper.Map<UserModel>(user));
        }
    }
}
