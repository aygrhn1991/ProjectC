using ProjectC.Extentions.Helpers;
using ProjectC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectC.Extentions.Managers
{
    public class UserManager
    {
        public int? GetUserId()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("ProjectC");
            if (cookie == null)
                return null;
            int userid = Tools.JsonToObj(new SignInCookieModel(), cookie.Value).userid;
            return userid;
        }
    }
}