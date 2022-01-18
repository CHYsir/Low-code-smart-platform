using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Dto
{
     public  class RoleMenuDto:Volo.Abp.Application.Dtos.AuditedEntityDto<int>
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }
    }
}
