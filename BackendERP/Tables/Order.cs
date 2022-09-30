using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class Order
    {
        [Key]

        public int Order_id { get; set; }
        public double Total { get; set; }
        public DateTime Order_date { get; set; }
        [ForeignKey("User")]
        public int User_id { get; set; }

    }
}
