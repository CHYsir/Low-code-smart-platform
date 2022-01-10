using System;
using System.Collections.Generic;
using System.Text;
using LowCodeSmartPlatform.Localization;
using Volo.Abp.Application.Services;

namespace LowCodeSmartPlatform
{
    /* Inherit your application services from this class.
     */
    public abstract class LowCodeSmartPlatformAppService : ApplicationService
    {
        protected LowCodeSmartPlatformAppService()
        {
            LocalizationResource = typeof(LowCodeSmartPlatformResource);
        }
    }
}
