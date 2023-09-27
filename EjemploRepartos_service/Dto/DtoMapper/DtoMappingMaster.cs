using AutoMapper;
using EjemploRepartos_database.Entities;
using EjemploRepartos_service.Dto.DtoMaster;

namespace EjemploRepartos_service.Dto.DtoMapper
{
    public class DtoMappingMaster : Profile
    {
        public DtoMappingMaster()
        {
            CreateMap<MaeEstadoPedido, MasterDto>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.IdMaeEstadoPedido)).
                ForMember(dest => dest.Valor, opt => opt.MapFrom(s => s.Valor)).
                ForMember(dest => dest.Descripcion, opt => opt.MapFrom(s => s.Descripcion));

            CreateMap<MaeComida, MasterDto>().
               ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.IdMaeComida)).
               ForMember(dest => dest.Valor, opt => opt.MapFrom(s => s.Valor)).
               ForMember(dest => dest.Descripcion, opt => opt.MapFrom(s => s.Descripcion));
        }
    }
}
