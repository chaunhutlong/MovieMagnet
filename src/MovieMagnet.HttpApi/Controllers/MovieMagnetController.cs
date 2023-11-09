using MovieMagnet.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MovieMagnet.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MovieMagnetController : AbpControllerBase
{
    protected MovieMagnetController()
    {
        LocalizationResource = typeof(MovieMagnetResource);
    }
}
