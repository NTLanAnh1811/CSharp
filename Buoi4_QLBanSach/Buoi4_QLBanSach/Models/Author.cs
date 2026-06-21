using System;
using System.Collections.Generic;

namespace Buoi4_QLBanSach.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? BirthYear { get; set; }

    public string? Nationality { get; set; }

    public string? Biography { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
