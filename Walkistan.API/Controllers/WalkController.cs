﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Walkistan.API.Interfaces;
using Walkistan.API.Models.Domain;
using Walkistan.API.Models.Dto.Walk;
namespace Walkistan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;
        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await _walkRepository.GetAllAsync();

            return Ok(_mapper.Map<List<WalkDto>>(walksDomainModel));
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var existingWalk = await _walkRepository.GetByIdAsync(id);

            if(existingWalk == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(existingWalk));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // AddWalkDto to Walk Domain Model
            var deletedWalkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

            await _walkRepository.CreateAsync(deletedWalkDomainModel);

            var walkDto = _mapper.Map<WalkDto>(deletedWalkDomainModel);

            return CreatedAtAction(nameof(Get), new {id = walkDto.Id}, walkDto);
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, 
            [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // UpdateWalkRequestDto to Walk Domain Model
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

            var updatedWalkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);

            if (updatedWalkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(updatedWalkDomainModel));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var walkDomainModel = await _walkRepository.DeleteAsync(id);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}