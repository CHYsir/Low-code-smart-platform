using LowCodeSmartPlatform.Base;
using LowCodeSmartPlatform.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Iservice
{
    public interface ImenuService:Volo.Abp.Application.Services.IApplicationService
    {
        //树形菜单1
        List<MenuDto> TreeAsync();

        //树形菜单2
        //Task<List<MenuDto>> TreeAsync();
    }
}
