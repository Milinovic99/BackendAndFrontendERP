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
    [Route("api/korisnicki_servis")]
    [Produces("application/json")]
    public class UserServiceController : ControllerBase
    {
        private readonly IUserServiceRepository userServiceRepository;
        private readonly LinkGenerator linkGenerator; //Služi za generisanje putanje do neke akcije 
        private readonly IMapper mapper;


        public UserServiceController(IUserServiceRepository userServiceRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.userServiceRepository = userServiceRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public ActionResult<List<User_service>> GetUsers(string email=null)
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

            var users = userServiceRepository.GetUserServices(email);
            if (users == null || users.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<User_service>>(users));
        }

        [HttpGet("{userService_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<User_service> GetUserService(int userService_id)
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
            var userService = userServiceRepository.GetUserServiceById(userService_id);
            if (userService == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<User_service>(userService));
        }


        [HttpPost]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<User_service> CreateUserService(User_service userService)
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
                var pro = userServiceRepository.CreateUserService(userService);
                userServiceRepository.SaveChanges();
                // Dobar API treba da vrati lokator gde se taj resurs nalazi
                //    string location = linkGenerator.GetPathByAction("GetProduct", "Product", new { Product_id = pro.Product_id });
                return StatusCode(StatusCodes.Status200OK, mapper.Map<User_service>(pro));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{userService_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteUserService(int userService_id)
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
                var productModel = userServiceRepository.GetUserServiceById(userService_id);
                if (productModel == null)
                {
                    return NotFound();
                }
                userServiceRepository.DeleteUserService(userService_id);
                userServiceRepository.SaveChanges();
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
        public ActionResult<User_service> UpdateUserService(User_service userService)
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
                var complaintCheck = userServiceRepository.GetUserServiceById(userService.Service_id);
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                if (complaintCheck == null)
                {
                    return NotFound();
                }
                mapper.Map(userService, complaintCheck);
                userServiceRepository.SaveChanges();
                return Ok(mapper.Map<User_service>(complaintCheck));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
