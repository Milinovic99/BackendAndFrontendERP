using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class Product_User
    {
        [Key]
        public int Product_user_id { get; set; }

        [ForeignKey("Product")]
        public int Product_id { get; set; }
        public Product Product { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }

        public int QuantityOfBoughtProducts { get; set; }
    }
}
