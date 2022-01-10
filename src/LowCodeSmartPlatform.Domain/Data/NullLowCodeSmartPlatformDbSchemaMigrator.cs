using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LowCodeSmartPlatform.Data
{
    /* This is used if database provider does't define
     * ILowCodeSmartPlatformDbSchemaMigrator implementation.
     */
    public class NullLowCodeSmartPlatformDbSchemaMigrator : ILowCodeSmartPlatformDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}