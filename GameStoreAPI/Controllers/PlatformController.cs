using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Business.Services;
using GameStoreAPI.DTO.Platform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private IMapper _mapper;
        private IPlatformService _platformService;

        public PlatformController(IMapper mapper, IPlatformService platformService)
        {
            _mapper = mapper;
            _platformService = platformService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllPlatforms")]
        public async Task<ActionResult<PlatformDTO>> GetAllPlatformsAsync()
        {
            IEnumerable<Platform> platformModels = await _platformService.GetAllPlatformsAsync();
            IEnumerable<PlatformDTO> platformDTOs = _mapper.Map<IEnumerable<PlatformDTO>>(platformModels);

            if (platformDTOs == null || platformDTOs.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(platformDTOs);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetASpecificPlatform")]
        public async Task<ActionResult<PlatformDTO>> GetPlatformByIDAsync(int id)
        {
            Platform platform = await _platformService.GetPlatformByIDAsync(id);
            PlatformDTO platformDTO = _mapper.Map<PlatformDTO>(platform);

            if (platformDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(platformDTO);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddPlatform")]
        public async Task<ActionResult> AddPlatformAsync(AddPlatformDTO platformDTO)
        {
            if (ModelState.IsValid)
            {
                Platform platform = _mapper.Map<Platform>(platformDTO);
                await _platformService.AddPlatformAsync(platform);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdatePlatform")]
        public async Task<ActionResult> UpdatePlatformAsync(int id, UpdatePlatformDTO platformDTO)
        {
            if (ModelState.IsValid)
            {
                Platform platform = _mapper.Map<Platform>(platformDTO);
                await _platformService.UpdatePlatformAsync(id, platform);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeletePlatform")]
        public async Task<ActionResult> DeletePlatformAsync(int id)
        {
            await _platformService.DeletePlatformByIDAsync(id);
            return NoContent();
        }
    }
}

