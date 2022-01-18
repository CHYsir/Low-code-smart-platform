using LowCodeSmartPlatform.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Iservice
{
    public interface ImemberRoleService:Volo.Abp.Application.Services.IApplicationService
    {
        int EditMemberRole(int UserId, List<int> RoleIds);
        int EditMemberRole(int UserId, List<RoleDto> Roles);

        List<MenuDto> rbac(int uid);
          
    }
}
