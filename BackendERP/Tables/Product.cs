using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        [Required(ErrorMessage = "Naziv proizvoda je neophodno unijeti")]
        public string Product_name { get; set; }
        public double Liter { get; set; }
        public int Product_quantity { get; set; }
        public double Price { get; set; }
        public bool On_action { get; set; }
        public string Discout { get; set; }
        public string Discount_price { get; set; }
        public string Image_url { get; set; }
        [ForeignKey("Product_category")]
        public int Category_id { get; set; }
        public Product_category Product_category { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<OrderProduct> Order_products { get; set; }
        
    }
}
