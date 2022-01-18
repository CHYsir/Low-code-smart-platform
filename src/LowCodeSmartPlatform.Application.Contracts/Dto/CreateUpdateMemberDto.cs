using LowCodeSmartPlatform.MyEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCodeSmartPlatform.Dto
{
    //对DTO进行验证，由ABP框架自动验证.
    public class CreateUpdateMemberDto
    {
        [Required]
        public string UserName { get; set; }  //用户名
        [Required]
        public string Passwprd { get; set; }  //用户密码

        public int LgoinStatus { get; set; }   //登录状态
        public string Detailed { get; set; }    //详细信息
        public int Sex { get; set; }     //性别
        public string UserAccount { get; set; }   //注册账号
        public string Phone { get; set; }      //手机号
        public MemberType MemberType { get; set; } = MemberType.LevelOne;  //会员类型
    }
}
