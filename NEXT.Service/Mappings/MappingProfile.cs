using AutoMapper;
using NEXT.Domain.Entities;
using NEXT.Service.DTOs.Posts;

namespace NEXT.Service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, PostForResultDto>().ReverseMap();
        CreateMap<Post, PostForCreationDto>().ReverseMap();
        CreateMap<Post, PostForUpdateDto>().ReverseMap();
    }
}
