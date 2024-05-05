using NightWatchBackend.Database.Models;

namespace NightWatchBackend.Communication
{
    public class MovieData
    {
        public int MovieId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public TimeOnly Length { get; set; }

        public DateOnly? RelasedOn { get; set; }

        public int AgeRating { get; set; }

        public string ThumbnailPath { get; set; }

        public string FilePath { get; set; }



     
    }
}
