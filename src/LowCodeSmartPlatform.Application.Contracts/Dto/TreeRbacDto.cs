using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Dto
{
    public class TreeRbacDto:Volo.Abp.Application.Dtos.AuditedEntityDto<int>
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



        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

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
