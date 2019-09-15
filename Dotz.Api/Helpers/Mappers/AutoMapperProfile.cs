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
        }

        private void MapModelsToEntities()
        {
            CreateMap<Models.Address.AddressModel, Address>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatedAt, opt => opt.Ignore())
                .ForMember(d => d.User, opt => opt.Ignore());
        }
    }
}
