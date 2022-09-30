using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class Rating
    {
        [Key]
        public int Rating_id { get; set; }

        public int Grade { get; set; }
        public string Comment { get; set; }
        [ForeignKey("Product")]
        public int Product_id { get; set; }
        [ForeignKey("User")]
        public int User_id { get; set; }

    }
}
