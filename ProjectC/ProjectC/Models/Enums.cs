using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectC.Models
{
    public enum IdentityType:int
    {
        phone,
        email,
    }
    public enum Result : int
    {
        success,
        failed,
    }
}