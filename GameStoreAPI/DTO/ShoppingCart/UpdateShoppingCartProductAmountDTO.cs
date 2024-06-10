using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.ShoppingCart
{
    public class UpdateShoppingCartProductAmountDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [Range(0, 20, ErrorMessage = "The Amount must be between 0 and 20 inclusive.")]
        public int Amount { get; set; }
    }
}
