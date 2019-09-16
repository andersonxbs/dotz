using AutoMapper;
using Dotz.Api.Controllers.Abstractions;
using Dotz.Api.Models.Order;
using Dotz.Api.Models.Shared;
using Dotz.Domain.Contracts.Repositories;
using Dotz.Domain.Entities;
using Dotz.Domain.Enumerators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : DotzControllerBase
    {
        private readonly IUnityOfWork _repositories;
        private readonly IMapper _mapper;

        public OrderController(
            IUnityOfWork repositories,
            IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(IEnumerable<OrderItemInputModel> orderItemModels)
        {
            var user = await _repositories.Users.GetByIdAsync(CurrentUserId);

            if (user.Address == null)
                return BadRequest(new ErrorModel(
                         $"There is not an address registered yet. " +
                         $"Request {Url.Action(nameof(AddressController.Post), nameof(AddressController))} using POST HTTP method in order to register it."));

            var products = await _repositories.Products
                .GetAsync(orderItemModels.Select(d => d.ProductId).ToArray());

            var orderItems =_mapper.Map<ICollection<OrderItem>>(orderItemModels);

            foreach (var item in orderItems)
            {
                var product = products.FirstOrDefault(d => d.Id == item.ProductId);

                if (product == null)
                    return BadRequest(new ErrorModel(
                         $"There is not a product with id {item.ProductId}."));

                if (product.Quantity < item.Quantity)
                    return BadRequest(new ErrorModel(
                         $"The requested quantity of product '{product.Title}' is more than the available."));

                item.UnityPoints = product.Points;
                product.Quantity -= item.Quantity;
            }

            var order = await _repositories.Orders.NewAsync(user);
            order.SetItems(orderItems);

            if (user.Account.PointBalance < order.TotalPoints)
                return BadRequest(new ErrorModel(
                    $"Your point balance is insuficient for getting the requested products."));

            user.Account.SetTransaction(
                TransactionType.Debit,
                "Purchase",
                order.TotalPoints);

            await _repositories.CommitChangesAsync();

            var orderModel = _mapper.Map<OrderModel>(order);

            return Created(
                Url.Action(nameof(GetById), new { id = order.Id }),
                orderModel);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var orders = await _repositories.Orders.GetByUserIdAsync(CurrentUserId);

            return Ok(_mapper.Map<IEnumerable<OrderModel>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var order = await _repositories.Orders.GetByIdAsync(id);
            
            if (order.User.Id != CurrentUserId)
                return new ForbidResult("Your have no permission to get this order.");

            return Ok(_mapper.Map<OrderModel>(order));
        }
    }
}