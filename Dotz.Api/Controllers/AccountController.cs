using AutoMapper;
using Dotz.Api.Controllers.Abstractions;
using Dotz.Api.Models.Account;
using Dotz.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var account = await _repositories.Accounts.GetByUserIdAsync(CurrentUserId);

            return Ok(_mapper.Map<AccountModel>(account));
        }

        [HttpGet("statement")]
        public async Task<ActionResult> GetTransactions()
        {
            var account = await _repositories.Accounts.GetByUserIdAsync(CurrentUserId);

            return Ok(_mapper.Map<IEnumerable<AccountTransactionModel>>(account.Transactions));
        }
    }
}