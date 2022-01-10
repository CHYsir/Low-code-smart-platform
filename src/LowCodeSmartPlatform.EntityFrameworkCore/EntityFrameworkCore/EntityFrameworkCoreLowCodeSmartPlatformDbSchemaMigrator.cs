using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LowCodeSmartPlatform.Data;
using Volo.Abp.DependencyInjection;

namespace LowCodeSmartPlatform.EntityFrameworkCore
{
    public class EntityFrameworkCoreLowCodeSmartPlatformDbSchemaMigrator
        : ILowCodeSmartPlatformDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreLowCodeSmartPlatformDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the LowCodeSmartPlatformDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<LowCodeSmartPlatformDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
