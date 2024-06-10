using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.GameProduct
{
    public class UpdateGameProductStockDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [Range(0, 20, ErrorMessage = "The stock must be between 0 and 20 inclusive.")]
        public int Stock { get; set; }
    }
}
