using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Jwt
{
    //可以将这些数据写到配置文件appsetting.json中，然后读取
    public class Const
    {
        /// <summary>
        /// 密匙
        /// </summary>
        public static string SecurityKey = "ABCDEFATADFEATEFATDAFWFEAFDTAEFAEFAEFA";
        /// <summary>
        /// 签发人
        /// </summary>
        public static string Issuer = "http://mytest.jwt.com/lcg";
        /// <summary>
        /// 受众
        /// </summary>
        public static string Aduience = "http://mytest.jwt.com/lcg";
    }


    //生成token的方法
    public class Create
    {
        public static string CreateToken(string userName)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new  DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                new Claim(ClaimTypes.Name, userName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Const.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: Const.Issuer,
            audience: Const.Aduience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
