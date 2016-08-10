using ProjectC.Extentions.Entity;
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
        ProjectCEntity entity = new ProjectCEntity();

        #region 页面
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region 注册表单验证
        public ActionResult CheckRepeatPhone(string phone)
        {
            var query = entity.phone_validate_code.FirstOrDefault(p => p.phone == phone);
            if (query == null)
                return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckValidateCode(string validateCode)
        {
            if (Session["ValidateCode"] != null)
            {
                if (validateCode.ToLower() != Session["ValidateCode"].ToString().ToLower())
                    return Json(false, JsonRequestBehavior.AllowGet);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckPhoneValidateCode(string phoneValidateCode)
        {

            if (phoneValidateCode != "1111")
                return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }








        public ActionResult CheckRepeatEmail(string email)
        {
            if (email == "111@111.com")
                return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }



        #endregion

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
        public ActionResult GetPhoneValidateCode(string phone)
        {
            string codStr = PhoneValidateCode.CreatePhoneValidateCode(4);
            phone_validate_code code = entity.phone_validate_code.FirstOrDefault(p => p.phone == phone);
            if (code != null)
            {
                code.validate_code = codStr;
            }
            else
            {
                phone_validate_code new_code = new phone_validate_code();
                new_code.phone = phone;
                new_code.validate_code = codStr;
                entity.phone_validate_code.Add(new_code);
            }
            //"您的验证码为：" + code + "，请尽快进行验证。（该验证码30分钟内有效）【职前招聘】";
            string url = "http://www.stongnet.com/sdkhttp/sendsms.aspx";
            string content = "您的验证码为：" + codStr + "，请尽快进行验证。（该验证码30分钟内有效）【职前招聘】";
            string param = "reg=101100-WEB-HUAX-402265&pwd=BSUAKCWJ&sourceadd=&phone=" + phone + "&content=" + content;
            PhoneValidateCode.SendPhoneValidateCode_Post(url, param);
            if (entity.SaveChanges() > 0)
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}