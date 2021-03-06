﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectC.Models
{
    public class Register_Phone_Model
    {
        public string phone { get; set; }
        public string validatecode { get; set; }
        public string phonevalidatecode { get; set; }
        public string phonepassword { get; set; }
    }
    public class Register_Email_Model
    {
        public string email { get; set; }
        public string emailpassword { get; set; }
    }
    public class LoginModel
    {
        public string account { get; set; }
        public string password { get; set; }
    }
    public class SignInCookieModel
    {
        public int userid { get; set; }
        public string roles { get; set; }
        public bool isAuthenticated { get; set; }
    }
    public class ResetPassword_Phone_Model
    {
        public string phone { get; set; }
        public string password { get; set; }
    }
    public class ResetPassword_Email_Model
    {
        public string email { get; set; }
    }
}