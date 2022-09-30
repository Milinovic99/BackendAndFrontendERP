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
    [Route("api/porudzbina")]
    [Produces("application/json")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly LinkGenerator linkGenerator; //Služi za generisanje putanje do neke akcije 
        private readonly IMapper mapper;


        public OrderController(IOrderRepository orderRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Consumes("application/json")]
        public ActionResult<List<Order>> GetOrders()
        {
            

            var order = orderRepository.GetOrders();
            if (order == null || order.Count == 0)
            {
                return NoContent();
            }

            return Ok(mapper.Map<List<Order>>(order));
        }

        [HttpGet("{order_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Order> GetOrderById(int order_id)
        {
            
            var delivery = orderRepository.GetOrderById(order_id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Order>(delivery));
        }


        [HttpPost]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<Order> CreateOrder([FromQuery] Order payment)
        {
           
            try
            {
                Order pro = orderRepository.CreateOrder(payment);
                orderRepository.SaveChanges();
                // Dobar API treba da vrati lokator gde se taj resurs nalazi
                // string location = linkGenerator.GetPathByAction("GetDeliveryData", "Delivery_data", new { delivery = pro.Delivery_id });
                return StatusCode(StatusCodes.Status200OK, pro);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{order_id}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult DeleteOrder(int payment_id)
        {
           

            try
            {
                var productModel = orderRepository.GetOrderById(payment_id);
                if (productModel == null)
                {
                    return NotFound();
                }
                orderRepository.DeleteOrder(payment_id);
                orderRepository.SaveChanges();
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
        public ActionResult<Order> UpdateOrder(Order payment)
        {
           
            try
            {
                var complaintCheck = orderRepository.GetOrderById(payment.Order_id);
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                if (complaintCheck == null)
                {
                    return NotFound();
                }
                mapper.Map(payment, complaintCheck);
                orderRepository.SaveChanges();
                return Ok(mapper.Map<Order>(complaintCheck));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
    
}
}
