using System;
using System.Collections.Generic;

namespace Buoi4_QLBanSach.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int? PublishedYear { get; set; }

    public int? Pages { get; set; }

    public string? Language { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
