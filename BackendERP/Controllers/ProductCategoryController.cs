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
    [Route("api/kategorije")]
    [Produces("application/json")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly LinkGenerator linkGenerator; //Služi za generisanje putanje do neke akcije 
        private readonly IMapper mapper;


        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public ActionResult<List<Product_category>> GetProductCategories(string kategorija=null)
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

            var proCategory = productCategoryRepository.GetProductCategories(kategorija);
            if (proCategory == null || proCategory.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<Product_category>>(proCategory));
        }

        [HttpGet("{proCategory_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Product_category> GetProductCategoryById(int proCategory_id)
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
            var proCategory = productCategoryRepository.GetProductCategoryById(proCategory_id);
            if (proCategory == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Product_category>(proCategory));
        }


        [HttpPost]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<Product_category> CreateProductCategory([FromQuery] Product_category proCategory)
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
                Product_category pro = productCategoryRepository.CreateProductCategory(proCategory);
                productCategoryRepository.SaveChanges();
                // Dobar API treba da vrati lokator gde se taj resurs nalazi
                // string location = linkGenerator.GetPathByAction("GetDeliveryData", "Delivery_data", new { delivery = pro.Delivery_id });
                return StatusCode(StatusCodes.Status200OK, pro);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{proCategory_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteProductCategory(int proCategory_id)
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
                var productModel = productCategoryRepository.GetProductCategoryById(proCategory_id);
                if (productModel == null)
                {
                    return NotFound();
                }
                productCategoryRepository.DeleteProductCategory(proCategory_id);
                productCategoryRepository.SaveChanges();
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
        public ActionResult<Product_category> UpdateProductCategory(Product_category proCategory)
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
                var complaintCheck = productCategoryRepository.GetProductCategoryById(proCategory.Category_id);
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                if (complaintCheck == null)
                {
                    return NotFound();
                }
                mapper.Map(proCategory, complaintCheck);
                productCategoryRepository.SaveChanges();
                return Ok(mapper.Map<Product_category>(complaintCheck));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

    }
}
