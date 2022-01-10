using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LowCodeSmartPlatform.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class LowCodeSmartPlatformDbContextFactory : IDesignTimeDbContextFactory<LowCodeSmartPlatformDbContext>
    {
        public LowCodeSmartPlatformDbContext CreateDbContext(string[] args)
        {
            LowCodeSmartPlatformEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<LowCodeSmartPlatformDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new LowCodeSmartPlatformDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LowCodeSmartPlatform.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
