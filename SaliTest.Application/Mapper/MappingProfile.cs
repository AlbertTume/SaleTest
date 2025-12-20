using AutoMapper;
using SaliTest.Application.DTOs;
using SaliTest.Domain.Entities;

namespace SaliTest.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Producto, ProductoDto>();
        }
    }
}
