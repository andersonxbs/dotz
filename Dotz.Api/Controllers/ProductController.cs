using AutoMapper;
using Dotz.Api.Controllers.Abstractions;
using Dotz.Api.Models.Product;
using Dotz.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/product")]
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
       
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _repositories.Products.GetAsync();

            return Ok(_mapper.Map<IEnumerable<ProductModel>>(products));
        }
    }
}