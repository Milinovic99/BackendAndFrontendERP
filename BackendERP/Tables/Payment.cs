using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class Payment
    {
        [Key]

        public int Payment_id { get; set; }
        public double Total { get; set; }
        public DateTime Payment_date { get; set; }
        [ForeignKey("User")]
        public int User_id { get; set; }
     //   public User User { get; set; }
    }
}
