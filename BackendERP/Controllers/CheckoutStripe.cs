using BackendERP.Data;
using BackendERP.Tables;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Controllers
{
    [Route("create-checkout-session")]
    [ApiController]
    [Consumes("application/json")]

    public class CheckoutStripe : Controller
    {
        List<SessionLineItemOptions> LineItems123 = new();
        private readonly IProductRepository productRepository;

    public CheckoutStripe(IProductRepository productRepository)
    {
      this.productRepository = productRepository;
    }

        [HttpPost]
        public ActionResult Create(Tables.Product[] product)
        {
          List<Tables.Product> productList = new();
           for(int p=0; p<product.Length; p++)
            {
                LineItems123.Add(
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {

                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {

                                Name = product[p].Product_name,
                                
                            },
                            UnitAmount = (long)product[p].Price,
                            Currency = "eur",
                            
                        },
                        Quantity = product[p].Product_quantity,     
                        
                    }                 
                    );
        productList.Add(product[p]);      
            }
      productRepository.ReduceProductsOnInventory(productList);
      
      var options = new SessionCreateOptions
            {
                
                LineItems = LineItems123,

                    Mode = "payment",
                    SuccessUrl = "http://localhost:4200/home",
                    CancelUrl = "http://localhost:4200/beer",
                };
            

            var service = new SessionService();
            Session session = service.Create(options);

            return Ok( new { session.Id } );
        }



    }
}
    
