using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeSmartPlatform.Base.Paged
{
    //实现IListResult接口, 继承IListResult, 在构造函数中为其赋值

    public class ListResult<T> : IListResult<T>
    {
        IReadOnlyList<T> item;

        public IReadOnlyList<T> Item 
        {
            get => item ?? (item = new List<T>());
            set => item = value;
        }

        public ListResult() { }

        public ListResult(IReadOnlyList<T> item)
        {
            Item = item;
        }
    }
}
