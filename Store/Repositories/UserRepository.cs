using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Repositories
{
    public class UserRepository
    {
        public static bool verify(string username, string password)
        {
            if (username == "admin" && password == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}