using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Dto
{
    public  class RoleDto:Volo.Abp.Application.Dtos.AuditedEntityDto<int>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        public string RoleDescribe { get; set; }

        /// <summary>
        /// 角色级别
        /// </summary>
        public string RoleLevel { get; set; }
    }
}
