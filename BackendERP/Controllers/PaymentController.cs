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
    [Route("api/placanje")]
    [Produces("application/json")]
    public class PaymentController:ControllerBase
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly LinkGenerator linkGenerator; //Služi za generisanje putanje do neke akcije 
        private readonly IMapper mapper;


        public PaymentController(IPaymentRepository paymentRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public ActionResult<List<Payment>> GetDeliveryPricelists()
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

            var payment = paymentRepository.GetPayments();
            if (payment == null || payment.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<Payment>>(payment));
        }

        [HttpGet("{delivery_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Payment> GetPaymentById(int payment_id)
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
            var delivery = paymentRepository.GetPaymentById(payment_id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Payment>(delivery));
        }


        [HttpPost]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<Payment> CreatePayment([FromQuery] Payment payment)
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
                Payment pro = paymentRepository.CreatePayment(payment);
                paymentRepository.SaveChanges();
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
        public IActionResult DeletePayment(int payment_id)
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
                var productModel = paymentRepository.GetPaymentById(payment_id);
                if (productModel == null)
                {
                    return NotFound();
                }
                paymentRepository.DeletePayment(payment_id);
                paymentRepository.SaveChanges();
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
        public ActionResult<Payment> UpdatePayment(Payment payment)
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
                var complaintCheck = paymentRepository.GetPaymentById(payment.Payment_id);
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                if (complaintCheck == null)
                {
                    return NotFound();
                }
                mapper.Map(payment, complaintCheck);
                paymentRepository.SaveChanges();
                return Ok(mapper.Map<Payment>(complaintCheck));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    
}
}
