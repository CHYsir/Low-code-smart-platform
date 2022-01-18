using LowCodeSmartPlatform.MyEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace LowCodeSmartPlatform.Enitiys
{
    //.Domain 包含实体、领域服务和其核心域对象
    //.Shared 包含与客户共享的枚举、常量和其它相关域对象

    //Abp提供两个基本的基类: AggregateRoot和Entity. Aggregate Root是领域驱动设计 概念之一


    //会员类
    [Table("tb_shopping_member")]
    public class MemberModel : Volo.Abp.Domain.Entities.Auditing.AuditedAggregateRoot<int>
    {
        public string UserName { get; set; }  //用户名
        public string Passwprd { get; set; }   //用户密码
        public int LgoinStatus { get; set; }   //登录状态
        public string Detailed { get; set; }    //详细信息
        public int Sex { get; set; }     //性别
        public string UserAccount { get; set; }   //注册账号
        public string Phone { get; set; }       //手机号

        //其中会员类型用的是枚举，所以在.Shared项目新建MemberType枚举
        public MemberType MemberType { get; set; }  //会员类型
    }
}
