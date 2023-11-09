using Volo.Abp.Settings;

namespace MovieMagnet.Settings;

public class MovieMagnetSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MovieMagnetSettings.MySetting1));
    }
}
