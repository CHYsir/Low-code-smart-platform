using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Base.Paged
{
    //分页响应实体接口：IPagedList, 它同时也要接受一个泛型参数 T, 接口继承了IListResult<T>和IHasTotalCount
    public interface IPagedList<T>:IListResult<T>,IHasTotalCount
    {

    }
}
