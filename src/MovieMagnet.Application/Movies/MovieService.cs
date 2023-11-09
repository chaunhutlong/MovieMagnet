using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MovieMagnet.Movies;

public class MovieService : MovieMagnetAppService, IMovieService
{
    private readonly IRepository<Movie, long> _movieRepository;
    
    public MovieService(IRepository<Movie, long> movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public async Task<PagedResultDto<MovieDto> > GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await _movieRepository.WithDetailsAsync();

        queryable = queryable
                .OrderBy(input.Sorting ?? nameof(Movie.Title))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
        
        var movies = await AsyncExecuter.ToListAsync(queryable);
        
        return new PagedResultDto<MovieDto>(
            queryable.Count(),
            ObjectMapper.Map<List<Movie>, List<MovieDto>>(movies)
        );
    }
}