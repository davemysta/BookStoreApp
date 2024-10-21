using BookStore.API.Data.Models;

namespace BookStore.API.Data.DTOs
{
    public class BookListItemDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }      

        public string? Image { get; set; }

        public decimal? Price { get; set; }

        public int? AuthorId { get; set; }

        public string? AuthorName { get; set; }
    }
}
