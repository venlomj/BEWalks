using AutoMapper;
using BEWalks.API.CustomActionFilters;
using BEWalks.API.Data;
using BEWalks.API.Models.Domain;
using BEWalks.API.Models.DTO;
using BEWalks.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BEWalks.API.Controllers
{
    [Route("api/regions")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly BEWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(BEWalksDbContext dbContext,
            IRegionRepository regionRepository,
            IMapper mapper,
            ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        // [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Get data from the database
                var regionsDomain = await regionRepository.GetAllAsync();

                // Map Domain Model to DTOs
                var response = mapper.Map<List<Region>>(regionsDomain);

                // Return DTOs
                logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Region Domain Model From Database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map/Convert Region Domain to Region DTO
            var response = mapper.Map<RegionDto>(regionDomain);

            // Return DTO back to client
            return Ok(response);
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto request)
        {
            // Map or Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(request);

            // Use Domain Model to create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain Model back to DTO
            var response = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto request)
        {
            // Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(request);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO
            var response = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // return deleted region
            // Convert Domain Model to DTO
            var response = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(response);
        }


    }
}
