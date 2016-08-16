using ProjectC.Extentions.Entity;
using ProjectC.Extentions.Helpers;
using ProjectC.Extentions.Managers;
using ProjectC.Models;
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

        SignInManager SignInManager = new SignInManager();
        UserManager UserManager = new UserManager();

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
            var query = entity.user_auth.FirstOrDefault(p => p.identity_type == IdentityType.phone && p.identifier == phone);
            if (query == null)
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckValidateCode(string validateCode)
        {
            if (Session["ValidateCode"] != null)
            {
                if (validateCode.ToLower() == Session["ValidateCode"].ToString().ToLower())
                    return Json(true, JsonRequestBehavior.AllowGet);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckPhoneValidateCode(string phone, string phoneValidateCode)
        {
            var query = entity.phone_validate_code.FirstOrDefault(p => p.phone == phone);
            if (query == null)
                return Json(false, JsonRequestBehavior.AllowGet);
            if (query.validate_code == phoneValidateCode && (DateTime.Now.Subtract(query.create_time).TotalMinutes < 30))
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckRepeatEmail(string email)
        {
            var query = entity.user_auth.FirstOrDefault(p => p.identity_type == IdentityType.email && p.identifier == email);
            if (query == null)
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult GetValidateCode()
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
                code.create_time = DateTime.Now;
            }
            else
            {
                phone_validate_code new_code = new phone_validate_code();
                new_code.phone = phone;
                new_code.validate_code = codStr;
                new_code.create_time = DateTime.Now;
                entity.phone_validate_code.Add(new_code);
            }
            //string url = "http://www.stongnet.com/sdkhttp/sendsms.aspx";
            //string content = "您的验证码为：" + codStr + "，请尽快进行验证。（该验证码30分钟内有效）【职前招聘】";
            //string param = "reg=101100-WEB-HUAX-402265&pwd=BSUAKCWJ&sourceadd=&phone=" + phone + "&content=" + content;
            //PhoneValidateCode.SendPhoneValidateCode_Post(url, param);
            if (entity.SaveChanges() > 0)
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register_Phone(Register_Phone_Model model)
        {
            user user = new user();
            entity.user.Add(user);
            entity.SaveChanges();

            user_auth_state user_auth_state = new user_auth_state();
            user_auth_state.access_failed_count = 0;
            user_auth_state.email_auth = false;
            user_auth_state.is_lockout = false;
            user_auth_state.phone_auth = true;
            user_auth_state.security_stamp = Guid.NewGuid().ToString("N");
            user_auth_state.user_id = user.id;
            entity.user_auth_state.Add(user_auth_state);

            user_auth user_auth = new user_auth();
            user_auth.user_id = user.id;
            user_auth.identity_type = IdentityType.phone;
            user_auth.identifier = model.phone;
            user_auth.credential = model.phonepassword;
            entity.user_auth.Add(user_auth);

            SignInManager.SignIn(user.id);

            if (entity.SaveChanges() > 0)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Error", "Home", new { errorMessage = "注册过程中发生意外" });
        }
        public ActionResult Register_Email(Register_Email_Model model)
        {
            user user = new user();
            entity.user.Add(user);
            entity.SaveChanges();

            user_auth_state user_auth_state = new user_auth_state();
            user_auth_state.access_failed_count = 0;
            user_auth_state.email_auth = false;
            user_auth_state.is_lockout = false;
            user_auth_state.phone_auth = false;
            user_auth_state.security_stamp = Guid.NewGuid().ToString("N");
            user_auth_state.user_id = user.id;
            entity.user_auth_state.Add(user_auth_state);

            user_auth user_auth = new user_auth();
            user_auth.user_id = user.id;
            user_auth.identity_type = IdentityType.email;
            user_auth.identifier = model.email;
            user_auth.credential = model.emailpassword;
            entity.user_auth.Add(user_auth);

            SignInManager.SignIn(user.id);

            if (entity.SaveChanges() > 0)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Error", "Home", new { errorMessage = "注册过程中发生意外" });
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var query = entity.user_auth.FirstOrDefault(p => p.identifier == model.account);
            if (query != null)
            {
                if (query.credential == model.password)
                {
                    SignInManager.SignIn(query.user_id);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}