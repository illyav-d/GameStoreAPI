using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Business.Services;
using GameStoreAPI.DTO.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartProductController : ControllerBase
    {
        IMapper _mapper;
        IShoppingCartProductService _shoppingCartProductService;

        public ShoppingCartProductController(IMapper mapper, IShoppingCartProductService shoppingCartProductService)
        {
            _mapper = mapper;
            _shoppingCartProductService = shoppingCartProductService;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("GetAllShoppingCartProducts")]
        public async Task<ActionResult<ShoppingCartProductWithUserDTO>> GetAllShoppingCartProductsAsync()
        {
            IEnumerable<ShoppingCartProduct> shoppingCartProductModels = await _shoppingCartProductService.GetAllShoppingCartProductsAsync();
            IEnumerable<ShoppingCartProductWithUserDTO> shoppingCartProductDTOs = _mapper.Map<IEnumerable<ShoppingCartProductWithUserDTO>>(shoppingCartProductModels);

            if (shoppingCartProductDTOs == null || shoppingCartProductDTOs.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(shoppingCartProductDTOs);
            }
        }

        [Authorize(Roles = "User")]
        [HttpPut]
        [Route("UpdateShoppingItemAmount")]
        public async Task<ActionResult<UpdateShoppingCartProductAmountDTO>> UpdateShoppingCartProductAmountAsync(int id, UpdateShoppingCartProductAmountDTO updateShoppingCartProductDTO)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartProduct shoppingCartProduct = _mapper.Map<ShoppingCartProduct>(updateShoppingCartProductDTO);
                await _shoppingCartProductService.UpdateProductAmountAsync(id, shoppingCartProduct);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("AddShoppingCartProduct")]
        public async Task<ActionResult> AddShoppingCartProductAsync(AddShoppingCartProductDTO addShoppingCartProductDTO)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartProduct shoppingCartProduct = _mapper.Map<ShoppingCartProduct>(addShoppingCartProductDTO);
                await _shoppingCartProductService.AddShoppingCartProductAsync(shoppingCartProduct);
                return Created();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("DeleteShoppingCartProduct")]
        public async Task<ActionResult> DeleteShoppingCartProductAsync(int id)
        {
            await _shoppingCartProductService.DeleteShoppingCartProductByIDAsync(id);
            return NoContent();
        }

        [Authorize(Roles = "User")]
        [HttpDelete]
        [Route("DeleteUserShoppingCart")]
        public async Task<ActionResult> DeleteUserShoppingCartProductsAsync(int userID)
        {
            await _shoppingCartProductService.DeleteUserShoppingCartProductsByUserIDAsync(userID);
            return NoContent();
        }
    }
}
