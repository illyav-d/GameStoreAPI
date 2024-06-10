using System.ComponentModel.DataAnnotations;

namespace GameStoreAPI.DTO.User
{
    public class UpdateUserActiveStateDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        public bool Active { get; set; }
    }
}
