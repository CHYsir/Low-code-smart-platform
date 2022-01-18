using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Enitiys
{
    //用户角色表

    [Table("tb_memberrole")]
    public class MemberRoleModel:Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<int>
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
