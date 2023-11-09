using System;
using Volo.Abp.Application.Dtos;

namespace MovieMagnet.Genres;

public class GenreDto : AuditedEntityDto<long>
{
    public string Name { get; set; } = null!;
}