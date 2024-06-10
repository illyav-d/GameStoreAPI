using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.Platform
{
    public class UpdatePlatformDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(1, ErrorMessage = "The name must be at least 1 character long.")]
        [MaxLength(50, ErrorMessage = "The name can be at most 50 characters long.")]
        public string Name { get; set; }
    }
}
