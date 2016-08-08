using ProjectC.Extentions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckRepeatEmail(string email)
        {
            if (email == "111@111.com")
                return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckRepeatPhone(string phone)
        {
            if (phone == "11111111111")
                return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckValidateCode(string validateCode)
        {
            if (validateCode.ToLower() != Session["ValidateCode"].ToString().ToLower())
                return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckPhoneCode(string phoneCode)
        {
            if (phoneCode != "1111")
                return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPhoneCode(string phone)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetValidateCode(int random = 0)
        {
            string code = ValidateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            var codeBytes = ValidateCode.CreateValidateGraphic(code);
            Response.OutputStream.Write(codeBytes, 0, codeBytes.Length);
            Response.ContentType = "Image/jpeg";
            Response.Flush();
            Response.End();
            return null;
        }
    }
}