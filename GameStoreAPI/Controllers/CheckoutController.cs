using GameStoreAPI.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        IOrderService _orderService;

        public CheckoutController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        [Route("Checkout")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> CheckoutShoppingCartAsync(int customerID)
        {
            await _orderService.CheckoutAsync(customerID);
            return Created();
        }
    }
}
