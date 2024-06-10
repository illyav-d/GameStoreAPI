using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.GameProduct
{
    public class UpdateGameProductPriceDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price needs to be a positive number.")]
        public double PriceInEuro { get; set; }
    }
}
