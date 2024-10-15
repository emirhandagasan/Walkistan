using AutoMapper;
using Walkistan.API.Models.Domain;
using Walkistan.API.Models.Dto.Difficulty;
using Walkistan.API.Models.Dto.Region;
using Walkistan.API.Models.Dto.Walk;

namespace Walkistan.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();

            CreateMap<Region, AddRegionRequestDto>().ReverseMap();

            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();

            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();

            CreateMap<Walk, WalkDto>().ReverseMap();

            CreateMap<Difficulty, DifficultyDto>().ReverseMap();

            CreateMap<Walk, UpdateWalkRequestDto>().ReverseMap();
        }
    }
}
