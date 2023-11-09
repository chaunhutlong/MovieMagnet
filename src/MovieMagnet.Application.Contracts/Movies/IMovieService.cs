using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MovieMagnet.Movies;

public interface IMovieService : IApplicationService
{
    Task<PagedResultDto<MovieDto>> GetListAsync(PagedAndSortedResultRequestDto input);
}