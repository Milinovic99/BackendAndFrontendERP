using AutoMapper;
using BackendERP.Data;
using BackendERP.Tables;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/proizvod")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly LinkGenerator linkGenerator; 
        private readonly IMapper mapper;
      


        public ProductController(IProductRepository productRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public ActionResult<List<Product>> GetProducts(string product)
        {
           

            var proizvodi = productRepository.GetProducts(product);
            if (proizvodi == null || proizvodi.Count == 0)
            {
                return NoContent();
            }
            

            return Ok(mapper.Map<List<Product>>(proizvodi));
        }

        [HttpGet("{proizvod_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Product> GetProduct(int proizvod_id)
        {
           
            var proizvod = productRepository.GetProductById(proizvod_id);
            if (proizvod == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Product>(proizvod));
        }


        [HttpPost]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<Product> CreateProduct(Product proizvod)
        {        
            try
            {         
                var pro = productRepository.CreateProduct(proizvod);
                productRepository.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, mapper.Map<Product>(pro));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }
    [HttpPost("provjera_kolicine")]
    public ActionResult<bool> CheckQuantity(Product product)
    {
      try
      {
        var checkQuantity = productRepository.CheckQuantity(product);
        if (checkQuantity == true)
          return StatusCode(StatusCodes.Status200OK, checkQuantity);
        else
          return StatusCode(StatusCodes.Status200OK, checkQuantity);
      }
      catch
      {
        return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
      }
    }
        [HttpDelete("{product_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteProduct(int product_id)
        {
            

            try
            {
                var productModel = productRepository.GetProductById(product_id);
                if (productModel == null)
                {
                    return NotFound();
                }
                productRepository.DeleteProduct(product_id);
                productRepository.SaveChanges();
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
        public ActionResult<Product> UpdateProduct(Product proizvod)
        {
            
            try
            {
                var complaintCheck = productRepository.GetProductById(proizvod.Product_id);
             
                if (complaintCheck == null)
                {
                    return NotFound();
                }
                mapper.Map(proizvod, complaintCheck);
                productRepository.SaveChanges();
                return Ok(mapper.Map<Product>(complaintCheck));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }

    }
}
