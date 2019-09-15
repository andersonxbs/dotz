using AutoMapper;
using Dotz.Api.Controllers.Abstractions;
using Dotz.Api.Models.Address;
using Dotz.Api.Models.Shared;
using Dotz.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<ActionResult> Post(AddressModel addressModel)
        {
            var user = await _repositories.Users.GetByIdAsync(CurrentUserId);

            if (user.Address != null)
                return BadRequest(new ErrorModel(
                    $"An address is already registered. " +
                    $"Request {Url.Action(nameof(Put))} using PUT HTTP method in order to update it."));

            var address = await _repositories.Addresses.New(user);

            _mapper.Map(addressModel, address);

            await _repositories.CommitChangesAsync();

            addressModel.Id = address.Id;

            return Created(
                Url.Action(nameof(Get)), 
                addressModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(AddressModel addressModel)
        {
            var address = await _repositories.Addresses.GetByUserIdAsync(CurrentUserId);

            if (address == null)
                return BadRequest(new ErrorModel(
                    $"There is not an address registered yet. " +
                    $"Request {Url.Action(nameof(Post))} using POST HTTP method in order to register it."));

            _mapper.Map(addressModel, address);

            await _repositories.CommitChangesAsync();

            addressModel.Id = address.Id;

            return Ok(addressModel);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var address = await _repositories.Addresses.GetByUserIdAsync(CurrentUserId);

            return Ok(_mapper.Map<AddressModel>(address));
        }
    }
}