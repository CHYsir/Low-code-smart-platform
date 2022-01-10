using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Data
{
    public interface ILowCodeSmartPlatformDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
