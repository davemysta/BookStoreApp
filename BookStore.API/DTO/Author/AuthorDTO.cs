using BookStore.API.Data;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Author
{
    public class AuthorDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string Bio { get; set; }
    }
}
