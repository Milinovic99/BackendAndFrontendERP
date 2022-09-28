using BackendERP.Data;
using BackendERP.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackendERP.AuthHelpers
{
    public class AuthHelper:IAuthHelper
    {
        private readonly IConfiguration configuration;
        private readonly IUserRepository userRepository;
      
        public AuthHelper(IConfiguration configuration, IUserRepository userRepository)
        {
            this.configuration = configuration;
            this.userRepository = userRepository;
        }

        public bool AuthenticatePrincipal(AuthModel authModel)
        {
            if (userRepository.UserWithCredentialsExists(authModel))
            {
                return true;
            }
            return false;
        }



        public string GenerateJwt(AuthModel authModel)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                                             configuration["Jwt:Issuer"],
                                             null,
                                             expires: DateTime.Now.AddDays(1),
                                             signingCredentials: credentials
                                             );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }



        public HttpStatusCode AuthorizeAsync(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://localhost:44200/api/korisnik/authorize/{token}").Result;

                var responseContent = response.StatusCode;

                return responseContent;
            }
        }
    }
}
