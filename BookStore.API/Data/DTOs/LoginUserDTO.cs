using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
