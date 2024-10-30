using BookStore.API.Data;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.DTOs
{
    public class AuthorDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Bio { get; set; }

        public List<BookListItemDTO>? Books { get; set; }
    }
}
