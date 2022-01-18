using LowCodeSmartPlatform.MyEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Dto
{
    //Dto输出
    //学会看命名空间
    //在.Contracts项目，添加Dto类。在ABP服务中，所有的操作基类都来自CrudAppService，它需要DTO类。继承AuditeEntityDto，具有审计属性

     public class MemberDto:Volo.Abp.Application.Dtos.AuditedEntityDto<int>
    {
        public string UserName { get; set; }  //用户名
        public string Passwprd { get; set; }  //用户密码
        public int LgoinStatus { get; set; }   //登录状态
        public string Detailed { get; set; }    //详细信息
        public int Sex { get; set; }     //性别
        public string UserAccount { get; set; }   //注册账号
        public string Phone { get; set; }      //手机号
        public MemberType MemberType { get; set; }  //会员类型
    }
}
