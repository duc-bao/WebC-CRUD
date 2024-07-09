using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebC_CRUD.Model.DTO.Request;
using WebC_CRUD.Model.DTO.Response;
using WebC_CRUD.Model.Entity;
using WebC_CRUD.Repository;

namespace WebC_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalkController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequest addWalkRequest)
        {
            // Map DTO to entity
            var walk = mapper.Map<Walk>(addWalkRequest);
            await walkRepository.CreateAsync(walk);
            return Ok(mapper.Map<WalkDTO>(walk));

        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var walks = await walkRepository.GetAllAsync();
            var walkDTO = mapper.Map<List<WalkDTO>>(walks);
            return Ok(walkDTO);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await walkRepository.GetWalkByIdAsync(id);
            var walkDTO = mapper.Map<WalkDTO>(walk);
            return Ok(walkDTO);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            // Map to entity
            var walk = mapper.Map<Walk>(updateWalkRequest);
            var walkResponse = walkRepository.UpdateWalkAsync(walk, id);
            if (walkResponse != null)
            {
                return NotFound();
            }
            // Map entity to DTO
            var walkDTO = mapper.Map<WalkDTO>(walkResponse);
            return Ok(walkDTO);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var walk = await walkRepository.DeleteWalkByIdAsync(id);
            // Map to  DTO
            var walkDTO = mapper.Map<WalkDTO>(walk);
            return Ok(walkDTO);
        }

    }
}
