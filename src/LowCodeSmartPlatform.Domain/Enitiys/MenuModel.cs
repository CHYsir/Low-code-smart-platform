using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Enitiys
{
    //菜单表

    [Table("tb_menu")]
    public class MenuModel:Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<int>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单子集
        /// </summary>
        public string MenuChildren { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public int SupId { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string MenuUrl { get; set; }
    }
}
