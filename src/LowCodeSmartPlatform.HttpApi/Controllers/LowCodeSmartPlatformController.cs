using LowCodeSmartPlatform.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LowCodeSmartPlatform.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class LowCodeSmartPlatformController : AbpControllerBase
    {
        protected LowCodeSmartPlatformController()
        {
            LocalizationResource = typeof(LowCodeSmartPlatformResource);
        }
    }
}