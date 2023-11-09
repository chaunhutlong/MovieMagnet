using AutoMapper;
using MovieMagnet.Genres;
using MovieMagnet.Movies;

namespace MovieMagnet;

public class MovieMagnetApplicationAutoMapperProfile : Profile
{
    public MovieMagnetApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Movie, MovieDto>();
        CreateMap<Genre, GenreDto>();
    }
}
