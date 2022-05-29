using BackendERP.AuthHelpers;
using BackendERP.Data;
using BackendERP.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Controllers
{
    [ApiController]
    [Route("api/korisnici")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthHelper authenticationHelper;
        private readonly IUserRepository userRepository;

        public AuthController(IAuthHelper authenticationHelper,IUserRepository userRepository)
        {
            this.authenticationHelper = authenticationHelper;
            this.userRepository = userRepository;
        }

        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthModel principal)
        {
            //Pokušaj autentifikacije
            if (authenticationHelper.AuthenticatePrincipal(principal))
            {
                var tokenString = authenticationHelper.GenerateJwt(principal);
                return Ok(new { token = tokenString });
            }

            //Ukoliko autentifikacija nije uspela vraća se status 401
            return Unauthorized();
        }
    }
}
