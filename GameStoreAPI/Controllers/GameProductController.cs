using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Business.Services;
using GameStoreAPI.DTO.GameProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameProductController : ControllerBase
    {
        IMapper _mapper;
        IGameProductService _gameProductService;

        public GameProductController(IMapper mapper, IGameProductService gameProductService)
        {
            _mapper = mapper;
            _gameProductService = gameProductService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetAllGameProducts")]
        public async Task<ActionResult<GameProductDTO>> GetAllGameProductsAsync(int page = 1, int items = 10)
        {
            IEnumerable<GameProduct> gameProductModels = await _gameProductService.GetAllGameProductsAsync(page, items);
            IEnumerable<GameProductDTO> gameProductsDTO = _mapper.Map<IEnumerable<GameProductDTO>>(gameProductModels);

            if (gameProductsDTO == null || gameProductsDTO.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(gameProductsDTO);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllActiveGameProducts")]
        public async Task<ActionResult<GameProductDTO>> GetAllGameProductsActiveAsync(int page = 1, int items = 10)
        {
            IEnumerable<GameProduct> gameProductModels = await _gameProductService.GetAllGameProductsActiveAsync(page, items);
            IEnumerable<GameProductDTO> gameProductsDTO = _mapper.Map<IEnumerable<GameProductDTO>>(gameProductModels);

            if (gameProductsDTO == null || gameProductsDTO.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(gameProductsDTO);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetGameProductByID")]
        public async Task<ActionResult<GameProductDTO>> GetGameProductByIDAsync(int id)
        {
            GameProduct gameProduct = await _gameProductService.GetGameProductByIDAsync(id);
            GameProductDTO gameProductDTO = _mapper.Map<GameProductDTO>(gameProduct);

            if (gameProductDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(gameProductDTO);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetGameProductByGenreID")]
        public async Task<ActionResult<GameProductDTO>> GetGameProductByGenreIDAsync(int genreID, int page = 1, int items = 10)
        {
            IEnumerable<GameProduct> gameProducts = await _gameProductService.GetGamesByGenreIDAsync(page, items, genreID);
            IEnumerable<GameProductDTO> gameProductsDTO = _mapper.Map<IEnumerable<GameProductDTO>>(gameProducts);

            if (gameProductsDTO == null || gameProductsDTO.Count() == 0)
            {
                return NotFound(gameProductsDTO);
            }
            else
            {
                return Ok(gameProductsDTO);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetGameProductByPlatformID")]
        public async Task<ActionResult<GameProductDTO>> GetGameProductByPlatformIDAsync(int platformID, int page = 1, int items = 10)
        {
            IEnumerable<GameProduct> gameProducts = await _gameProductService.GetGamesByPlatformIDAsync(page, items, platformID);
            IEnumerable<GameProductDTO> gameProductsDTO = _mapper.Map<IEnumerable<GameProductDTO>>(gameProducts);

            if (gameProductsDTO == null || gameProductsDTO.Count() == 0)
            {
                return NotFound(gameProductsDTO);
            }
            else
            {
                return Ok(gameProductsDTO);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetGamesByUserInput")]
        public async Task<ActionResult<GameProductDTO>> GetGamesByUserInputAsync(string userInput, int page = 1, int items = 10)
        {
            IEnumerable<GameProduct> gameProductModels = await _gameProductService.GetGamesByNameAsync(page, items, userInput);
            IEnumerable<GameProductDTO> gameProductsDTO = _mapper.Map<IEnumerable<GameProductDTO>>(gameProductModels);

            if (gameProductsDTO == null || gameProductsDTO.Count() == 0)
            {
                return NotFound(gameProductsDTO);
            }
            else
            {
                return Ok(gameProductsDTO);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddGameProduct")]
        public async Task<ActionResult> AddGameProductAsync(AddGameProductDTO addGameProductDTO)
        {
            if (ModelState.IsValid)
            {
                GameProduct gameProduct = _mapper.Map<GameProduct>(addGameProductDTO);
                await _gameProductService.AddGameProductAsync(gameProduct);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateGameProduct")]
        public async Task<ActionResult> UpdateGameProductAsync(int id, UpdateGameProductDTO updateGameProductDTO)
        {
            if (ModelState.IsValid)
            {
                GameProduct gameProduct = _mapper.Map<GameProduct>(updateGameProductDTO);
                await _gameProductService.UpdateGameProductAsync(id, gameProduct);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateGameProductPrice")]
        public async Task<ActionResult> UpdateGameProductPriceAsync(int id, UpdateGameProductPriceDTO updateGameProductPriceDTO)
        {
            if (ModelState.IsValid)
            {
                GameProduct gameProduct = _mapper.Map<GameProduct>(updateGameProductPriceDTO);
                await _gameProductService.UpdateGameProductPriceAsync(id, gameProduct);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateGameProductStock")]
        public async Task<ActionResult> UpdateGameProductStockAsync(int id, UpdateGameProductStockDTO updateGameProductStockDTO)
        {
            if (ModelState.IsValid)
            {
                GameProduct gameProduct = _mapper.Map<GameProduct>(updateGameProductStockDTO);
                await _gameProductService.UpdateGameProductStockAsync(id, gameProduct);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("UpdateGameProductActiveState")]
        public async Task<ActionResult> UpdateGameProductActiveStateAsync(int id, UpdateGameProductActiveStateDTO gameProductStateDTO)
        {
            if (ModelState.IsValid)
            {
                GameProduct gameProduct = _mapper.Map<GameProduct>(gameProductStateDTO);
                await _gameProductService.UpdateGameProductActiveStateAsync(id, gameProduct);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
