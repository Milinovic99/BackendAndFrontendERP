using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class Product_category
    {
        [Key]

        public int Category_id { get; set; }
        [StringLength(40, MinimumLength = 3)]
        public string Category_name { get; set; }

       public List<Product> Products { get; set; }
    }
}
