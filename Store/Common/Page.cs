using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Common
{
    public class Page<T>
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling((decimal)this.RecordCount / this.PageSize);
            }
        }

        public object Data { get; set; }

        public Page(int pageNo, int pageSize, int recordCount, List<T> data)
        {
            this.PageNo = pageNo;
            this.PageSize = pageSize;
            this.RecordCount = recordCount;
            this.Data = data;
        }

    }
}