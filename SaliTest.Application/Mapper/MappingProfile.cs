using AutoMapper;
using SaliTest.Application.DTOs;
using SaliTest.Domain.Entities;

namespace SaliTest.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Message, opt => opt.Ignore()) // Assuming Message is not in User entity
                .ForMember(dest => dest.IsSuccess, opt => opt.Ignore()); // Assuming IsSuccess is not in User entity
        }
    }
}
