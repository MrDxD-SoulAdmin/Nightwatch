using System;
using System.Collections.Generic;

namespace NightWatchBackend.Database.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateOnly BirthDate { get; set; }

    public string ProfilePath { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public virtual ICollection<Movie> MoviesNavigation { get; set; } = new List<Movie>();
}
