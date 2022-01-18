using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeSmartPlatform.Helepe
{
    public sealed  class MD5
    {
        //标准md5算法
        public static string GetMd5(string tempString)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider HashMd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return BitConverter.ToString(HashMd5.ComputeHash(Encoding.Default.GetBytes(tempString))).Replace("-", "").ToLower();
        }
    }
}
