using AutoMapper;
using Dotz.Api.Controllers.Abstractions;
using Dotz.Api.Models.User;
using Dotz.Domain.Contracts.Providers;
using Dotz.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : DotzControllerBase
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
            var registerInfo = await _securityProvider.Register(
                registerModel.Name, 
                registerModel.Email, 
                registerModel.Password);

            if (!registerInfo.Result.Succeeded)
                return BadRequest(registerInfo.Result.Errors.Where(d => !d.Code.Equals("DuplicateUserName")));

            await _repositories.Accounts.NewAsync(registerInfo.User.Id);
            await _repositories.CommitChangesAsync();

            return Created(
                Url.Action(nameof(Me)), 
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
            var authInfo = await _securityProvider.Authenticate(authModel.Email, authModel.Password);

            if (!authInfo.Result.Succeeded)
                return BadRequest(new IdentityError
                {
                    Code = "InvalidCredentials",
                    Description = "Invalid email or password."
                });

            return Ok(new AuthResultModel
            {
                User = _mapper.Map<UserModel>(authInfo.User),
                Token = authInfo.Token
            });
        }

        [HttpGet("me")]
        public async Task<ActionResult> Me()
        {
            var user = await _repositories.Users.GetByIdAsync(CurrentUserId);

            return Ok(_mapper.Map<UserModel>(user));
        }
    }
}
