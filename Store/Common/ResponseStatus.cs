using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Store.Common
{
    /// <summary>
    /// 返回状态码枚举类型
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("Error")]
        ERROR = -1,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("Success")]
        SUCCESS = 0,

        /// <summary>
        /// 未授权
        /// </summary>
        [Description("Unauthorized")]
        UNAUTHORIZED = 401,

        /// <summary>
        /// 没有找到
        /// </summary>
        [Description("Not Found")]
        NOT_FOUND = 404
    }
}