using AutoMapper;
using BackendERP.Data;
using BackendERP.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Controllers
{
    [ApiController]
    [Route("api/korisnik")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly LinkGenerator linkGenerator; //Služi za generisanje putanje do neke akcije 
        private readonly IMapper mapper;


        public UserController(IUserRepository userRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public ActionResult<List<User>> GetUsers(string name=null,string lastName= null,string userName=null )
        {
            //   string token = Request.Headers["token"].ToString();
            //  string[] split = token.Split('#');
            // if (split[1] != "administrator")
            //   return Unauthorized();
            // }
            //HttpStatusCode res = fileService.AuthorizeAsync(token).Result;
            //if (res.ToString() != "OK")
            // {
            //    return Unauthorized();
            //}

            var users = userRepository.GetUsers(name,lastName,userName);
            if (users == null || users.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<User>>(users));
        }

        [HttpGet("{user_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<User> GetUser(int user_id)
        {
            //   string token = Request.Headers["token"].ToString();
            //  string[] split = token.Split('#');
            // if (split[1] != "administrator" )
            //{ 
            //   return Unauthorized();
            //}
            //HttpStatusCode res = fileService.AuthorizeAsync(token).Result;
            //if (res.ToString() != "OK")
            //{
            //   return Unauthorized();
            //}
            var user = userRepository.GetUserById(user_id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<User>(user));
        }


        [HttpPost]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<User> CreateUser(User user)
        {
            //  string token = Request.Headers["token"].ToString();
            // string[] split = token.Split('#');
            //if (split[1] != "administrator" )
            //{ 
            //   return Unauthorized();
            //}
            //HttpStatusCode res = fileService.AuthorizeAsync(token).Result;
            //if (res.ToString() != "OK")
            //{
            //   return Unauthorized();
            //}
            try
            {
                var pro = userRepository.CreateUser(user);
                userRepository.SaveChanges();
                // Dobar API treba da vrati lokator gde se taj resurs nalazi
                //    string location = linkGenerator.GetPathByAction("GetProduct", "Product", new { Product_id = pro.Product_id });
                return StatusCode(StatusCodes.Status200OK, mapper.Map<User>(pro));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{User_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteUser(int user_id)
        {
            //    string token = Request.Headers["token"].ToString();
            //   string[] split = token.Split('#');
            //  if (split[1] != "administrator")
            // { 
            //    return Unauthorized();
            //}
            //HttpStatusCode res = fileService.AuthorizeAsync(token).Result;
            //if (res.ToString() != "OK")
            // {
            //    return Unauthorized();
            //}

            try
            {
                var productModel = userRepository.GetUserById(user_id);
                if (productModel == null)
                {
                    return NotFound();
                }
                userRepository.DeleteUser(user_id);
                userRepository.SaveChanges();
                // Status iz familije 2xx koji se koristi kada se ne vraca nikakav objekat, ali naglasava da je sve u redu

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        [HttpPut]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<User> UpdateUser(User user)
        {
            //   string token = Request.Headers["token"].ToString();
            //  string[] split = token.Split('#');
            // if (split[1] != "administrator" || split[1] != "menadzer" || split[1] != "licitant"
            //    || split[1] != "tehnicki sektetar" || split[1] != "prva komisija" || split[1] != "operator nadmetanja")
            //{
            //   return Unauthorized();
            //}
            //HttpStatusCode res = fileService.AuthorizeAsync(token).Result;
            //if (res.ToString() != "OK")
            //{
            //   return Unauthorized();
            //}
            try
            {
                var complaintCheck = userRepository.GetUserById(user.User_id);
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                if (complaintCheck == null)
                {
                    return NotFound();
                }
                mapper.Map(user, complaintCheck);
                userRepository.SaveChanges();
                return Ok(mapper.Map<User>(complaintCheck));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
