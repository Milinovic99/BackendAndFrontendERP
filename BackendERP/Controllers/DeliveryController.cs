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
    [Route("api/dostava")]
    [Produces("application/json")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryRepository deliveryDataRepository;
        private readonly LinkGenerator linkGenerator; //Služi za generisanje putanje do neke akcije 
        private readonly IMapper mapper;


        public DeliveryController(IDeliveryRepository deliveryDataRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.deliveryDataRepository = deliveryDataRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public ActionResult<List<Delivery>> GetDeliveryData(string address=null,string city=null)
        {
            

            var delivery = deliveryDataRepository.GetDeliveries(address,city);
            if (delivery == null || delivery.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<Delivery>>(delivery));
        }

        [HttpGet("{delivery_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Delivery> GetDelivery(int delivery_id)
        {
           
            var delivery = deliveryDataRepository.GetDeliveryById(delivery_id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Delivery>(delivery));
        }


        [HttpPost]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<Delivery> CreateDelivery([FromQuery] Delivery delivery)
        {
            
            try
            {
                Delivery pro = deliveryDataRepository.CreateDelivery(delivery);
                deliveryDataRepository.SaveChanges();
                // Dobar API treba da vrati lokator gde se taj resurs nalazi
               // string location = linkGenerator.GetPathByAction("GetDeliveryData", "Delivery_data", new { delivery = pro.Delivery_id });
                return StatusCode(StatusCodes.Status200OK, pro);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{delivery_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteDelivery(int delivery_id)
        {
           

            try
            {
                var productModel = deliveryDataRepository.GetDeliveryById(delivery_id);
                if (productModel == null)
                {
                    return NotFound();
                }
                deliveryDataRepository.DeleteDelivery(delivery_id);
                deliveryDataRepository.SaveChanges();
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
        public ActionResult<Delivery> UpdateDelivery(Delivery delivery)
        {
            
            try
            {
                var complaintCheck = deliveryDataRepository.GetDeliveryById(delivery.Delivery_id);
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                if (complaintCheck == null)
                {
                    return NotFound();
                }
                mapper.Map(delivery, complaintCheck);
                deliveryDataRepository.SaveChanges();
                return Ok(mapper.Map<Delivery>(complaintCheck));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    }
}
