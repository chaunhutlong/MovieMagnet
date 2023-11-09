using MovieMagnet.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MovieMagnet;

[DependsOn(
    typeof(MovieMagnetEntityFrameworkCoreTestModule)
    )]
public class MovieMagnetDomainTestModule : AbpModule
{

}
