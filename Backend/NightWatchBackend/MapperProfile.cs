using AutoMapper;
using NightWatchBackend.Database.Models;
using NightWatchBackend.Resources;

namespace NightWatchBackend
{
    public class MapperProfile:Profile
    {
        public MapperProfile() {
            CreateMap<User, UserResources>().ForMember(x => x.DislikedMovieNavigationTitle,y => y.MapFrom(z => z.Movies.Select(a => a.Title)));
            CreateMap<Movie, MovieResources>();
            CreateMap<Genre, GenreResources>().ForMember(x => x.Genrelist, y => y.MapFrom(z => z.Movies.Select(a => a.Title)));
        }
    }
}
