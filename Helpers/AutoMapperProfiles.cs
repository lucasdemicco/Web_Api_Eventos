using AutoMapper;
using Eventos.DTO;
using Eventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EventoDto, Evento>().ReverseMap()
                .ForMember(dest => dest.Palestrantes, opt => {
                    opt.MapFrom(src => src.PalestranteEventos.Select(x => x.Palestrante).ToList());
                    });  

            CreateMap<PalestranteDto, Palestrante>().ReverseMap()
                .ForMember(dest => dest.Eventos, opt =>{
                    opt.MapFrom(src => src.PalestranteEventos.Select(x => x.Evento).ToList());
                });  

            CreateMap<LoteDto, Lote>().ReverseMap();  

            CreateMap<RedeSocialDto, RedeSocial>().ReverseMap();  
        }
    }
}
