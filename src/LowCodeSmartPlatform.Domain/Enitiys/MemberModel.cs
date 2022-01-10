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
    //会员类
    [Table("tb_shopping_member")]
    public class MemberModel : BasicAggregateRoot<Guid>
    {
        public string UserName { get; set; }  //用户名
        public string Passwprd { get; set; }  //用户密码
        public string Phone { get; set; }      //手机号
        public MemberType MemberType { get; set; }  //会员类型
    }
}
