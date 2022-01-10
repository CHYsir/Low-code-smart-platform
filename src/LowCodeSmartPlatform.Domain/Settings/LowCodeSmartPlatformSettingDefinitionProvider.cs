using Volo.Abp.Settings;

namespace LowCodeSmartPlatform.Settings
{
    public class LowCodeSmartPlatformSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(LowCodeSmartPlatformSettings.MySetting1));
        }
    }
}
