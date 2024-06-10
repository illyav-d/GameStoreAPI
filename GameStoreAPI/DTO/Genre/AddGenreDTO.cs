using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.Genre
{
    public class AddGenreDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(1, ErrorMessage = "Name has to contain at least 1 character.")]
        [MaxLength(50, ErrorMessage = "Name can contain a max of 50 characters.")]
        public string Name { get; set; }
    }
}
