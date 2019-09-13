using AutoMapper;
using Dotz.Api.Controllers.Abstractions;
using Dotz.Api.Models.Address;
using Dotz.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : DotzControllerBase
    {
        private readonly IUnityOfWork _repositories;
        private readonly IMapper _mapper;

        public AddressController(
            IUnityOfWork repositories,
            IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        public async Task<ActionResult> Post(AddressModel addressModel)
        {
            var user = await _repositories.Users.GetByIdAsync(CurrentUserId);
            var address = await _repositories.Addresses.New(user);

            _mapper.Map(addressModel, address);

            await _repositories.CommitChangesAsync();

            addressModel.Id = address.Id;

            return Created($"{address.Id}", addressModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var address = await _repositories.Addresses.GetByIdAsync(id);

            if (address == null)
                return BadRequest($"Id {id} does not reference to any existing address.");
            
            if (address.User.Id != CurrentUserId)
                return Forbid("You have no permission to see this address.");

            return Ok(_mapper.Map<AddressModel>(address));
        }
    }
}