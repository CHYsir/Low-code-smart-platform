using LowCodeSmartPlatform.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LowCodeSmartPlatform
{
    [DependsOn(
        typeof(LowCodeSmartPlatformEntityFrameworkCoreTestModule)
        )]
    public class LowCodeSmartPlatformDomainTestModule : AbpModule
    {

    }
}