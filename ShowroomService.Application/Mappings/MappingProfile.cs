using AutoMapper;
using ShowroomService.Application.Dtos;
using ShowroomService.Domain.Entities;

namespace ShowroomService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Showroom, ShowroomDto>()
                .ForMember(dest => dest.Status,
                        opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}