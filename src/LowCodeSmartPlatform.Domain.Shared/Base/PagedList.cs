using LowCodeSmartPlatform.Base.Paged;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Base
{
    //分页响应实体实现类：PagedList，它同时也要接受一个泛型参数 T,  在构造函数中为其赋值

    /// <summary>
    /// 分页响应实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : ListResult<T>, IPagedList<T>
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }

        public PagedList() { }

        public PagedList(int total,IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}
