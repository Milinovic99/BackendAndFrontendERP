using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BackendERP.AuthHelpers
{
   public interface IAuthHelper
    {
        public bool AuthenticatePrincipal(AuthModel authModel);
        public string GenerateJwt(AuthModel authModel);
        public HttpStatusCode AuthorizeAsync(string token);
    }
}
