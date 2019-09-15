using AutoMapper;
using Dotz.Api.Controllers.Abstractions;
using Dotz.Api.Models.Account;
using Dotz.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : DotzControllerBase
    {
        private readonly IUnityOfWork _repositories;
        private readonly IMapper _mapper;

        public AccountController(
            IUnityOfWork repositories,
            IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var account = await _repositories.Addresses.GetByUserIdAsync(CurrentUserId);

            return Ok(_mapper.Map<AccountModel>(account));
        }
    }
}