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
        private readonly DatabaseContext context;

        public AuthController(IAuthHelper authenticationHelper,IUserRepository userRepository,DatabaseContext context)
        {
            this.authenticationHelper = authenticationHelper;
            this.userRepository = userRepository;
            this.context = context;
        }
        

        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthModel principal)
        {
            //Pokušaj autentifikacije
            if (authenticationHelper.AuthenticatePrincipal(principal))
            {
                User user = context.Users.FirstOrDefault(u => u.Email == principal.Email && u.Password
                  == principal.Password);
                var tokenString = authenticationHelper.GenerateJwt(principal);

                Container cont = new()
                {
                    user = user,
                    token = tokenString

                };

                return Ok(cont);

                
            }

            //Ukoliko autentifikacija nije uspela vraća se status 401
            return Unauthorized();
        }

        
    }
}
