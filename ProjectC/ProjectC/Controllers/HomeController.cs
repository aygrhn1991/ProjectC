using ProjectC.Extentions.Helpers;
using ProjectC.Extentions.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectC.Controllers
{
    [ProjectCAuthorize]
    public class HomeController : Controller
    {
        UserManager UserManager = new UserManager();
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Agreement()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Error(string errorMessage)
        {
            ViewBag.Error = errorMessage;
            return View();
        }
        [AllowAnonymous]
        public ActionResult Forbiden()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Test2()
        {
            var s = ValidateCode.CreateValidateGraphic(ValidateCode.CreateValidateCode(4));
            Response.OutputStream.Write(s,0,s.Length);
            Response.ContentType = "Image/jpeg";
            Response.Flush();
            Response.End();
            return null;
        }
    }
}