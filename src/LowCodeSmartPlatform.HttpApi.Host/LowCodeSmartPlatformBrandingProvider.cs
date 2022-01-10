using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace LowCodeSmartPlatform
{
    [Dependency(ReplaceServices = true)]
    public class LowCodeSmartPlatformBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "LowCodeSmartPlatform";
    }
}
