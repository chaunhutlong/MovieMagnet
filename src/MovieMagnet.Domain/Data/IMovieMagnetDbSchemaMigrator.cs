using System.Threading.Tasks;

namespace MovieMagnet.Data;

public interface IMovieMagnetDbSchemaMigrator
{
    Task MigrateAsync();
}
