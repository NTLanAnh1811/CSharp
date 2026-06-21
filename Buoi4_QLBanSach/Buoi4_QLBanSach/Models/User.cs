using System;
using System.Collections.Generic;

namespace Buoi4_QLBanSach.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime? CreatedAt { get; set; }
}
