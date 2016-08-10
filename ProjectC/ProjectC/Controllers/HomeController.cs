using ProjectC.Extentions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agreement()
        {
            return View();
        }
        public ActionResult Error(string errorMessage)
        {
            ViewBag.Error = errorMessage;
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
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