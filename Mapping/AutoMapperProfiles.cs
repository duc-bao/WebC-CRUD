using AutoMapper;
using WebC_CRUD.Model.Domain;
using WebC_CRUD.Model.DTO.Request;
using WebC_CRUD.Model.DTO.Response;
using WebC_CRUD.Model.Entity;

namespace WebC_CRUD.Mapping
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>()
               // .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name)) // Map 2 trường khác nhau về tên 
                .ReverseMap();
            CreateMap<AddRegionRequest, Region>().ReverseMap();
            CreateMap<UpdateRegionRequest, Region>().ReverseMap();
            CreateMap<AddWalkRequest, Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<UpdateWalkRequest, Walk>().ReverseMap();
            // Difficult
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();

           
        }
    }
}
