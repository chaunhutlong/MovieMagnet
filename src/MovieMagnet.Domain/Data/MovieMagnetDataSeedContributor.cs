using System;
using System.Threading.Tasks;
using MovieMagnet.Genres;
using MovieMagnet.Movies;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace MovieMagnet.Data;

public class MovieMagnetDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Movie, long> _movieRepository;
    private readonly IRepository<Genre, long> _genreRepository;
    
    public MovieMagnetDataSeedContributor(IRepository<Movie, long> movieRepository, IRepository<Genre, long> genreRepository)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        // Seed data for genres
        if (await _genreRepository.CountAsync() > 0)
        {
            return;
        }
    }
}