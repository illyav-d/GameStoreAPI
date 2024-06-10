using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.GameProduct
{
    public class AddGameProductDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(1, ErrorMessage = "The name must be at least 1 character long.")]
        [MaxLength(50, ErrorMessage = "The name can be at most 50 characters long.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [MinLength(1, ErrorMessage = "The description must be at least 1 character long.")]
        [MaxLength(500, ErrorMessage = "The description can be at most 500 characters long.")]
        public string Description { get; set; }


        public DateTime? ReleaseDate { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [MinLength(1, ErrorMessage = "The developer must be at least 1 character long.")]
        [MaxLength(100, ErrorMessage = "The developer can be at most 100 characters long.")]
        public string Developer { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [MinLength(1, ErrorMessage = "The publisher must be at least 1 character long.")]
        [MaxLength(100, ErrorMessage = "The publisher can be at most 100 characters long.")]
        public string Publisher { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Range(0, 18, ErrorMessage = "The minimum age must be between 0 and 18 inclusive.")]
        public int MinimumAge { get; set; }


        [MinLength(1, ErrorMessage = "The image URL must be at least 1 character long.")]
        public string? ImageURL { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price needs to be a positive number.")]
        public double PriceInEuro { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Range(0, 20, ErrorMessage = "The stock must be between 0 and 20 inclusive.")]
        public int Stock { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        public bool Active { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The genre ID must be at least 1.")]
        public int GenreID { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The platform ID must be at least 1.")]
        public int PlatformID { get; set; }
    }
}
