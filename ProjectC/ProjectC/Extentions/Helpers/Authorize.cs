﻿using ProjectC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ProjectC.Extentions.Helpers
{
    public class ProjectCAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = false;
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("ProjectC");
            if (cookie == null)
            {
                httpContext.Response.StatusCode = 401;
                return false;
            }
            SignInCookieModel user = Tools.JsonToObj(new SignInCookieModel(), cookie.Value);
            if (!user.isAuthenticated)
            {
                httpContext.Response.StatusCode = 401;
                return false;
            }
            string[] users = Users.Split(',');
            string[] roles = Roles.Split(',');
            if (roles.Length == 1 && string.IsNullOrWhiteSpace(roles[0]))
            {
                result = true;
            }
            else
            {
                string[] currentRoles = user.roles.Split(',');
                foreach (var role in roles)
                {
                    if (currentRoles.Contains(role))
                    {
                        result = true;
                        break;
                    }
                }
            }
            if (!result)
            {
                httpContext.Response.StatusCode = 403;
            }
            return result;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == 401)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                filterContext.Result = new RedirectResult("/Home/Forbiden");
            }
        }
    }
}