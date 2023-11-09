using MovieMagnet.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MovieMagnet.Permissions;

public class MovieMagnetPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MovieMagnetPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MovieMagnetPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MovieMagnetResource>(name);
    }
}
