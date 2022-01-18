using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Base.Paged
{
    //想要分页，数据总数肯定是必不可少的  此时还需要扩展一个分页的响应实体，当我们使用的时候，直接将分页响应实体作为上面写的ServiceResult<T>中的T参数，即可满足需求

    //总数接口IHasTotalCount
    public interface IHasTotalCount
    {
        /// <summary>
        /// 总数
        /// </summary>
        int Total { get; set; }
    }

}
