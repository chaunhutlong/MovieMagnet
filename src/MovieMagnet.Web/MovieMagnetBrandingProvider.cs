using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MovieMagnet.Web;

[Dependency(ReplaceServices = true)]
public class MovieMagnetBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MovieMagnet";
}
