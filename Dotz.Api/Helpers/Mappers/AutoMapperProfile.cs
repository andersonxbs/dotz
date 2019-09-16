using AutoMapper;
using Dotz.Domain.Entities;

namespace Dotz.Api.Helpers.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapEntitiesToModels();
            MapModelsToEntities();
        }

        private void MapEntitiesToModels()
        {
            CreateMap<User, Models.User.UserModel>();
            CreateMap<Address, Models.Address.AddressModel>();
            CreateMap<Account, Models.Account.AccountModel>();
            CreateMap<AccountTransaction, Models.Account.AccountTransactionModel>();
            CreateMap<Product, Models.Product.ProductModel>();
            CreateMap<Order, Models.Order.OrderModel>();
            CreateMap<OrderItem, Models.Order.OrderItemModel>()
                .ForMember(d => d.ProductTitle, opt => opt.MapFrom(d => d.Product.Title));
        }

        private void MapModelsToEntities()
        {
            CreateMap<Models.Address.AddressModel, Address>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatedAt, opt => opt.Ignore())
                .ForMember(d => d.User, opt => opt.Ignore());

            CreateMap<Models.Order.OrderItemInputModel, OrderItem>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatedAt, opt => opt.Ignore())
                .ForMember(d => d.UnityPoints, opt => opt.Ignore())
                .ForMember(d => d.Product, opt => opt.Ignore());
        }
    }
}
