using LowCodeSmartPlatform.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LowCodeSmartPlatform.Permissions
{
    public class LowCodeSmartPlatformPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LowCodeSmartPlatformPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(LowCodeSmartPlatformPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LowCodeSmartPlatformResource>(name);
        }
    }
}
