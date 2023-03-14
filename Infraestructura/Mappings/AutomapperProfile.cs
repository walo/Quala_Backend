using AutoMapper;
using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Mappings
{
    class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Wmoneda, WmonedaDto>();
            CreateMap<WmonedaDto, Wmoneda>();

            CreateMap<Wsucursal, WsucursalDto>()
                .ForMember(dest => dest.MndNombre, opt => opt.MapFrom(src => src.Mnd.MndNombre));
            CreateMap<WsucursalDto, Wsucursal>();
        }
    }
}
