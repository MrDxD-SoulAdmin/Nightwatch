namespace NightWatchBackend.Resources
{
    public class UserResources
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateOnly BirthDate { get; set; }

        public string ProfilePath { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<string> DislikedMovieNavigationTitle { get; set; } 
    }
}
