using AutoMapper;
using Game.Application.DTOs;
using Game.Domain.Entities;
namespace Game.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Jugador, JugadorDto>();
        }
    }
}
