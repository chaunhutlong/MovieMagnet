using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieMagnet.Data;
using Volo.Abp.DependencyInjection;

namespace MovieMagnet.EntityFrameworkCore;

public class EntityFrameworkCoreMovieMagnetDbSchemaMigrator
    : IMovieMagnetDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMovieMagnetDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MovieMagnetDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MovieMagnetDbContext>()
            .Database
            .MigrateAsync();
    }
}
