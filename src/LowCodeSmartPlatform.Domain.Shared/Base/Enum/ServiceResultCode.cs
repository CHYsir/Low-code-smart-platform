using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Base.Enum
{
    /// <summary>
    /// 服务层响应码枚举   200/500。分别代表 成功和失败
    /// </summary>
    public enum ServiceResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 200,

        /// <summary>
        /// 失败
        /// </summary>
        Failed = 500,
    }
}
