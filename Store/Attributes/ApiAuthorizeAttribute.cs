using Store.App_Start;
using Store.Common;
using Store.Models;
using Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace Store.Attributes
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Parameter != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Parameter;

                try
                {
                    //解密Ticket
                    var token = FormsAuthentication.Decrypt(encryptTicket).UserData;

                    //从Ticket里面获取用户名和密码
                    string[] tokens = token.Split('&');
                    if (tokens.Length == 2)
                    {
                        string username = tokens[0];
                        string password = tokens[1];

                        if (UserRepository.verify(username, password))
                        {
                            base.IsAuthorized(actionContext);
                        }
                        else
                        {
                            HandleUnauthorizedRequest(actionContext);
                        }
                    }
                    else
                    {
                        HandleUnauthorizedRequest(actionContext);
                    }
                }
                catch
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                HandleUnauthorizedRequest(actionContext);
            }
        }

        /// <summary>
        /// 数字签名
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        private bool verifySignature(HttpActionContext actionContext)
        {
            return true;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
            var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(Json.Encode(new ResponseEntity(ResponseStatus.UNAUTHORIZED)), Encoding.UTF8, "application/json");
        }
    }
}