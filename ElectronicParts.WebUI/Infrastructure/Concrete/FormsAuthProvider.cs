using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicParts.WebUI.Infrastructure.Abstract;
using System.Web.Security;

namespace ElectronicParts.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string userName, string password)
        {
            bool result = FormsAuthentication.Authenticate(userName, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(userName,false);
            }
            return result;
        }
    }
}