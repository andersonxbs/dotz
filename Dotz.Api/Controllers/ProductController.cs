using AutoMapper;
using Dotz.Api.Controllers.Abstractions;
using Dotz.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : DotzControllerBase
    {
        private readonly IUnityOfWork _repositories;
        private readonly IMapper _mapper;

        public ProductController(
            IUnityOfWork repositories,
            IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    var account = await _repositories.Accounts.GetByUserIdAsync(CurrentUserId);

        //    return Ok(_mapper.Map<AccountModel>(account));
        //}
    }
}