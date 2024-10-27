using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Walkistan.API.Data;
using Walkistan.API.Interfaces;
using Walkistan.API.Models.Domain;
using Walkistan.API.Models.Dto.Region;

namespace Walkistan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepository.GetAllAsync();
            

            return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
        }


        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomain));
        }


        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // AddRegionRequestDto to Domain Model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            await _regionRepository.CreateAsync(regionDomainModel);

            // Domain Model to RegionDto
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);


            return CreatedAtAction(nameof(Get), new { id = regionDto.Id}, regionDto);
        }


        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] int id,
            [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // UpdateRegionRequestDto to Region Domain Model
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);

            var updatedRegionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if(updatedRegionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(updatedRegionDomainModel));
        }


        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var domainRegion = await _regionRepository.DeleteAsync(id);

            if(domainRegion == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(domainRegion));
        }
    }
}
