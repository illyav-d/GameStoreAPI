using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.ShoppingCart
{
    public class AddShoppingCartProductDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The UserID must be at least 1.")]
        public int UserID { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The GameProductID must be at least 1.")]
        public int GameProductID { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Range(0, 20, ErrorMessage = "The Amount must be between 0 and 20 inclusive.")]
        public int Amount { get; set; }
    }
}
