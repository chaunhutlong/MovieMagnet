using MovieMagnet.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MovieMagnet.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MovieMagnetPageModel : AbpPageModel
{
    protected MovieMagnetPageModel()
    {
        LocalizationResourceType = typeof(MovieMagnetResource);
    }
}
