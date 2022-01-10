using LowCodeSmartPlatform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace LowCodeSmartPlatform.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(LowCodeSmartPlatformEntityFrameworkCoreModule),
        typeof(LowCodeSmartPlatformApplicationContractsModule)
        )]
    public class LowCodeSmartPlatformDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
