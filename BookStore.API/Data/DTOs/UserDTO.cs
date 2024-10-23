using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.DTOs
{
    public class UserDTO : LoginUserDTO
    {
        [Required]
        public string UserName {  get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}
