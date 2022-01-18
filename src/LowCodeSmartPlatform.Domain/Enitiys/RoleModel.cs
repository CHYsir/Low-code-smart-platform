using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Enitiys
{
    //角色表

    [Table("tb_role")]
    public  class RoleModel:Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<int>
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
