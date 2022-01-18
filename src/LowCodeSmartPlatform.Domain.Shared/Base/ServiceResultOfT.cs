using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Base
{
    //当我们需要返回其它各种复杂类型的数据，添加一个支持泛型的返回模型 ，针对需要返回参数的api（带分页的数据就没办法了）

    /// <summary>
    /// 服务层响应实体（泛型）     这里的T就是我们的返回结果，然后继承我们的ServiceResult，指定T为class
    /// </summary>
    public  class ServiceResult<T>:ServiceResult where T: class        
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        public  void IsSuccess(T result=null,string message = "",string token="")
        {
            Message = message;
            Code = Enum.ServiceResultCode.Succeed;
            Result = result;
            Token = token;
        }
    }
}
