using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Store.Filters
{
    public class ApiSecurityFilter : ActionFilterAttribute
    {
        //Timestamp
        //Signature
        //AppKey

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            string timestamp = String.Empty, signature = string.Empty, appKey = string.Empty;
            if (request.Headers.Contains("Timestamp"))
            {
                timestamp = HttpUtility.UrlDecode(request.Headers.GetValues("Timestamp").FirstOrDefault());
            }
            if (request.Headers.Contains("Signature"))
            {
                signature = HttpUtility.UrlDecode(request.Headers.GetValues("Signature").FirstOrDefault());
            }
            if (request.Headers.Contains("AppKey"))
            {
                appKey = HttpUtility.UrlDecode(request.Headers.GetValues("AppKey").FirstOrDefault());
            }

            //排除不需要进行签名验证的方法
            if (actionContext.ActionDescriptor.ActionName == "GetToken")
            {
                base.OnActionExecuting(actionContext);
                return;
            }

            //判断请求头是否包含以下参数
            /*
            if (string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(appKey))
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(Json.Encode(new ResponseEntity(ResponseStatus.UNAUTHORIZED)), Encoding.UTF8, "application/json");
                actionContext.Response = response;
                base.OnActionExecuting(actionContext);
                return;
            }
            */

            //判断Timestamp是否有效

            /*
            double ts1 = 0;
            double ts2 = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
            double ts = ts2 - ts1;
            if ((ts > (30 * 1000)) || (!double.TryParse(timestamp, out ts1)))
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(Json.Encode(new ResponseEntity(ResponseStatus.UNAUTHORIZED)), Encoding.UTF8, "application/json");
                actionContext.Response = response;
                base.OnActionExecuting(actionContext);
                return;
            }
            */

            //判断Signature是否有效

            base.OnActionExecuting(actionContext);
        }
    }
}