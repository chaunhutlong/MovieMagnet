using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MovieMagnet.Genres;

public interface IGenreService : IApplicationService
{
    Task<PagedResultDto<GenreDto>> GetListAsync(PagedAndSortedResultRequestDto input);
}