using LowCodeSmartPlatform.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Iservice
{
    //角色权限
     public  interface IroleMenuService:Volo.Abp.Application.Services.IApplicationService
    {
        int EditRoleMenu(int RoleId, List<int> MenuIds);
        int EditRoleMenu(int RoleId, List<MenuDto> Menus);
    }
}
