using System;
using System.Collections.Generic;

namespace NightWatchBackend.Database.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TimeOnly Length { get; set; }

    public DateOnly? RelasedOn { get; set; }

    public int AgeRating { get; set; }

    public string ThumbnailPath { get; set; }

    public string FilePath { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<User> UsersNavigation { get; set; } = new List<User>();
}
