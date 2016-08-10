using System;
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
    }
}