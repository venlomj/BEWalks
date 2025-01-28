using AutoMapper;
using Azure.Core;
using BEWalks.API.CustomActionFilters;
using BEWalks.API.Models.Domain;
using BEWalks.API.Models.DTO;
using BEWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BEWalks.API.Controllers
{
    [Route("api/walks")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper,
            IWalkRepository walkRepository
            )
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto request)
        {
            // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(request);

            await walkRepository.CreateAsync(walkDomainModel);

            var response = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy,
                isAscending ?? true, pageNumber, pageSize);

            var response = mapper.Map<List<WalkDto>>(walksDomainModel);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            var response = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto request)
        {
            var walkDomainModel = mapper.Map<Walk>(request);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            var response = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // return deleted region
            // Convert Domain Model to DTO
            var response = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(response);
        }
    }
}
