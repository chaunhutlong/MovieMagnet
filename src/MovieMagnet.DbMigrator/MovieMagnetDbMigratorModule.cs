using MovieMagnet.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MovieMagnet.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MovieMagnetEntityFrameworkCoreModule),
    typeof(MovieMagnetApplicationContractsModule)
    )]
public class MovieMagnetDbMigratorModule : AbpModule
{
}
