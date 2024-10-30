using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Models;

public partial class BookModel
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Year { get; set; }

    public string Isbn { get; set; } = null!;

    public string? Summary { get; set; }
    
    [StringLength(250)]
    public string? Image { get; set; }

    public decimal Price { get; set; }

    public int? AuthorId { get; set; }

    public virtual AuthorModel? Author { get; set; }
}
