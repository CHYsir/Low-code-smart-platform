using Volo.Abp.Modularity;

namespace LowCodeSmartPlatform
{
    [DependsOn(
        typeof(LowCodeSmartPlatformApplicationModule),
        typeof(LowCodeSmartPlatformDomainTestModule)
        )]
    public class LowCodeSmartPlatformApplicationTestModule : AbpModule
    {

    }
}