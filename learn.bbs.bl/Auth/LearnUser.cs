using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace learn.bbs.bl.Auth
{
    public class LearnUser : IPrincipal
    {
        private IIdentity _identity;

        public IIdentity Identity
        {
            get
            {
                if (_identity == null)
                {
                    _identity = null;//new FormsIdentity();

                    //FormsAuthenticationTicket
                }
                return _identity;
            }
            set
            {

            }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}
