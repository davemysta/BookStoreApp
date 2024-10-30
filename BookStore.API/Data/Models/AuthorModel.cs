using System;
using System.Collections.Generic;

namespace BookStore.API.Data.Models;

public partial class AuthorModel
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Bio { get; set; }

    public virtual ICollection<BookModel>? Books { get; set; } = new List<BookModel>();
}
