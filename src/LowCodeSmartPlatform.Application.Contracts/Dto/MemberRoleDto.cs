using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Dto
{
     public class MemberRoleDto:Volo.Abp.Application.Dtos.AuditedEntityDto<int>
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
    }
}
