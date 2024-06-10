using AutoMapper;
using GameStoreAPI.Business.Models;
using GameStoreAPI.Business.Services;
using GameStoreAPI.DTO.Genre;
using GameStoreAPI.DTO.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMapper _mapper;
        IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<ActionResult<GenreDTO>> GetAllOrdersAsync()
        {
            IEnumerable<Order> orderModels = await _orderService.GetAllOrdersAsync();
            IEnumerable<OrderDTO> orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orderModels);

            if (orderDTOs == null || orderDTOs.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(orderDTOs);
            }
        }

    }
}
