using ProjectC.Extentions.Helpers;
using ProjectC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectC.Extentions.Managers
{
    public class SignInManager
    {
        public void SignIn(int userid)
        {
            SignInCookieModel cookieModel = new SignInCookieModel();
            cookieModel.userid = userid;
            cookieModel.roles = "";
            cookieModel.isAuthenticated = true;
            HttpCookie cookie = new HttpCookie("ProjectC");
            cookie.Value = Tools.ObjToJson(cookieModel);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
    }
}