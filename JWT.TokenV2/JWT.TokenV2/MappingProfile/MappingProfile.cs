using AutoMapper;
using JWT.TokenV2.DTO;
using JWT.TokenV2.Model;

namespace JWT.TokenV2.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,UserRegisterDto>().ReverseMap();
        }
    }
}
