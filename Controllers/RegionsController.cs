using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebC_CRUD.CustomActionFilter;
using WebC_CRUD.Data;
using WebC_CRUD.Mapping;
using WebC_CRUD.Model.DTO.Request;
using WebC_CRUD.Model.DTO.Response;
using WebC_CRUD.Model.Entity;
using WebC_CRUD.Repository;

namespace WebC_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IRepository iRepository;
        private readonly IMapper mapper;
        public RegionsController(ApplicationDbContext applicationDbContext, IRepository repository, IMapper mapper) { 
            this.dbContext = applicationDbContext;
            this.iRepository = repository;  
            this.mapper = mapper;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await iRepository.GetAllAsync();
            // Convert Entity to DTO return 
           var regionDTO =  mapper.Map<List<RegionDTO>>(regions);

            return Ok(regionDTO);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id) {
            var region = await iRepository.GetRegionById(id);
            if (region == null) { 
                return NotFound();
            }
            // Convert Entity to DTO
            var regionDTO  = mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);  
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequest addRegionRequest)
        {
           
                // convert DTO to Entity
                var regionModel = mapper.Map<Region>(addRegionRequest);
                regionModel = await iRepository.CreateRegion(regionModel);
                // Map domain model to DTO
                var regionDTO = mapper.Map<RegionDTO>(regionModel);
                return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);
       
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> PutById([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            // Map to Entity
            var regionModel = mapper.Map<Region>(updateRegionRequest);
            var region = await iRepository.UpdateRegion(id, regionModel );
            // Map entity to DTO
            var regionDTO = mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
           var region =  await iRepository.DeleteRegion(id);
            // Map entity to DTO
            var regionDTO = mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }   
    }
}
