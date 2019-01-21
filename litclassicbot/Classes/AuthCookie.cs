using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace litclassicbot.Classes
{
    public class AuthCookie
    {
        public Guid NewUser()
        {
            return Guid.NewGuid();
        }
    }
}