using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Store.Models;
using System.Web.Security;
using System.Web;
using Store.Repositories;
using Store.Common;

namespace Store.App_Start
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpPost,Route("")]
        public ResponseEntity Login([FromBody] User user)
        {
            if (!UserRepository.verify(user.Username, user.Password))
            {
                return ResponseEntity.failure();
            }
            FormsAuthenticationTicket token = new FormsAuthenticationTicket(0, user.Username, DateTime.Now,
            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", user.Username, user.Password),
            FormsAuthentication.FormsCookiePath);
            return ResponseEntity.success(FormsAuthentication.Encrypt(token));
        }
    }
}
