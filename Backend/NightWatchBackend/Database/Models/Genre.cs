﻿using System;
using System.Collections.Generic;

namespace NightWatchBackend.Database.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
