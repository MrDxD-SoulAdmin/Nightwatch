using System;
using System.Collections.Generic;

namespace NightWatchBackend.Database.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string ProfilePath { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Movie> DislikedMovieNavigation { get; set; } = new List<Movie>();

    public virtual ICollection<Movie> LikedMovieNavigation { get; set; } = new List<Movie>();
}
