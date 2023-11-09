// using System.Threading.Tasks;
// using Volo.Abp.Application.Dtos;
// using Volo.Abp.Domain.Repositories;
//
// namespace MovieMagnet.Genres;
//
// public class GenreService : MovieMagnetAppService, IGenreService
// {
//     private readonly IRepository<Genre, long> _genreRepository;
//     
//     public GenreService(IRepository<Genre, long> genreRepository)
//     {
//         _genreRepository = genreRepository;
//     }
//     
//     public async Task<PagedResultDto<GenreDto>> GetListAsync(PagedAndSortedResultRequestDto input)
//     {
//         // var queryable = await _genreRepository.WithDetailsAsync(x => x.Movies);
// }