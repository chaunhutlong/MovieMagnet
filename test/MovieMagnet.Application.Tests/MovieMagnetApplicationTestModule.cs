using Volo.Abp.Modularity;

namespace MovieMagnet;

[DependsOn(
    typeof(MovieMagnetApplicationModule),
    typeof(MovieMagnetDomainTestModule)
    )]
public class MovieMagnetApplicationTestModule : AbpModule
{

}
