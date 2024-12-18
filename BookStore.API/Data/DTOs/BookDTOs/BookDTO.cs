﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.DTOs.BookDTOs
{
    public class BookDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [Required]
        [Range(1800, int.MaxValue)]
        public int? Year { get; set; }

        [Required]
        public string Isbn { get; set; } = null!;

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string? Summary { get; set; }

        public string? ImageData { get; set; }

        public string? OriginalImageName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        public int? AuthorId { get; set; }

        public string? AuthorName { get; set; }
    }
}
