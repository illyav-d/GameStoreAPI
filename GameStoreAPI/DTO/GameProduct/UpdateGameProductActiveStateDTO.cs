using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.GameProduct
{
    public class UpdateGameProductActiveStateDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        public bool Active { get; set; }
    }
}
