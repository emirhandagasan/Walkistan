using AutoMapper;
using Walkistan.API.Models.Domain;
using Walkistan.API.Models.Dto.Region;

namespace Walkistan.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();

            CreateMap<Region, AddRegionRequestDto>().ReverseMap();

            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();
        }
    }
}
