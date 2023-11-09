using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MovieMagnet.Data;

/* This is used if database provider does't define
 * IMovieMagnetDbSchemaMigrator implementation.
 */
public class NullMovieMagnetDbSchemaMigrator : IMovieMagnetDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
