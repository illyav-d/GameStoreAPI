using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.Order
{
    public class AddOrderDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The CustomerID must be at least 1.")]
        public int CustomerID { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price needs to be a positive number.")]
        public double TotalPriceInEuro { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public string[] GameTitles { get; set; }
    }
}
