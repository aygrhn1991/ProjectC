using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Check(string data)
        {
            if (data == "ookk")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetD(string user1,string password1)
        {
            return Json("getit",JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckRepeatEmail()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckRepeatPhone()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}