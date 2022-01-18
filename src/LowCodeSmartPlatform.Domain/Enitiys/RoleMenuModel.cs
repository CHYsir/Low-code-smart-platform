using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Enitiys
{
    //角色菜单表

    [Table("tb_rolemenu")]
    public class RoleMenuModel:Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<int>
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
