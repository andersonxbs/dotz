using AutoMapper;
using Dotz.Api.Models.User;
using Dotz.Domain.Entities;

namespace Dotz.Api.Helpers.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapEntitiesToModels();
        }

        private void MapEntitiesToModels()
        {
            CreateMap<User, UserModel>();
        }
    }
}
