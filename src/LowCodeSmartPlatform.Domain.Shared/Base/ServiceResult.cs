using LowCodeSmartPlatform.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Base
{
    //定义了 string 类型的 Message，bool 类型的 Success，Success取决于Code == ServiceResultCode.Succeed的结果。还有一个当前的时间戳Timestamp。其中还有IsSuccess(...)和IsFailed(...)方法，当我们成功返回数据或者当系统出错或者参数异常的时候执行

    //这个返回模型暂时只支持无需返回参数的api使用

    /// <summary>
    /// 服务层响应实体
    /// </summary>
   public class ServiceResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public ServiceResultCode Code { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 成功
        /// </summary>
        public bool Success => Code == ServiceResultCode.Succeed;

        /// <summary>
        /// 时间戳(毫秒)
        /// </summary>
        public long Timestamp { get; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"></param>
        public void IsSuccess(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="message"></param>
        public void IsFailed(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Failed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="exception"></param>
        public void IsFailed(Exception exception)
        {
            Message = exception.InnerException?.StackTrace;
            Code = ServiceResultCode.Failed;
        }
    }
}
