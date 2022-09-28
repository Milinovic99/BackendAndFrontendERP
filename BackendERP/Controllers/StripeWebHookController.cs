using BackendERP.Data;
using BackendERP.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Controllers
{
    [Route("webhook")]
    [ApiController]
    public class StripeWebHookController : Controller
    {
        const string secret = "whsec_7a91e779df8054368faa39e9fe5b17bf4cd1c298db490c9167bf371c3a8a54c5";
        private readonly IOrderRepository paymentRepository;
        private readonly DatabaseContext context;


        public StripeWebHookController(DatabaseContext context, IOrderRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {

                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                   Request.Headers["Stripe-Signature"],
                    secret
                  );
                Console.WriteLine(stripeEvent);
                // Handle the checkout.session.completed event
                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Stripe.Checkout.Session;
                    Console.WriteLine(session);


                    // Fulfill the purchase...
                    paymentRepository.FulfillOrder(session);
                }

                return Ok();
            }


            catch (StripeException e)
            {
                return BadRequest(e);
            }
        }

    }
}

