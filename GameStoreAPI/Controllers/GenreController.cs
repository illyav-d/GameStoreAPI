using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Business.Services;
using GameStoreAPI.DTO.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IMapper _mapper;
        IGenreService _genreService;

        public GenreController(IMapper mapper, IGenreService genreService)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllGenres")]
        public async Task<ActionResult<GenreDTO>> GetAllGenresAsync()
        {
            IEnumerable<Genre> genreModels = await _genreService.GetAllGenresAsync();
            IEnumerable<GenreDTO> genresDTO = _mapper.Map<IEnumerable<GenreDTO>>(genreModels);

            if (genresDTO == null || genresDTO.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(genresDTO);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetASpecificGenre")]
        public async Task<ActionResult<GenreDTO>> GetGenreByIDAsync(int id)
        {
            Genre genre = await _genreService.GetGenreByIDAsync(id);
            GenreDTO genreDTO = _mapper.Map<GenreDTO>(genre);

            if (genreDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(genreDTO);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddGenre")]
        public async Task<ActionResult> AddGenreAsync(AddGenreDTO genreDTO)
        {
            if (ModelState.IsValid)
            {
                Genre genre = _mapper.Map<Genre>(genreDTO);
                await _genreService.AddGenreAsync(genre);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateGenre")]
        public async Task<ActionResult> UpdateGenreAsync(int id, UpdateGenreDTO genreDTO)
        {
            if (ModelState.IsValid)
            {
                Genre genre = _mapper.Map<Genre>(genreDTO);
                await _genreService.UpdateGenreAsync(id, genre);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteGenre")]
        public async Task<ActionResult> DeleteGenreAsync(int id)
        {
            await _genreService.DeleteGenreByIDAsync(id);
            return NoContent();
        }
    }
}
