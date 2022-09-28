using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class Delivery
    {
        [Key]

        public int Delivery_id { get; set; }

        [Required(ErrorMessage = "Neophodno je unijeti broj telefona")]
     //   [RegularExpression(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Neispravan format!")]
        public string Phone_number { get; set; }
        [Required(ErrorMessage = "Neophodno je unijeti adresu")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Adresa mora sadrzati iskljucivo slova!")]
        [StringLength(40, MinimumLength = 5)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Neophodno je unijeti grad")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Grad mora sadrzati iskljucivo slova!")]
        [StringLength(40, MinimumLength = 5)]
        public string City { get; set; }
        [ForeignKey("Order")]
        public int Order_id { get; set; }

        public Order Order { get; set; }
    }
}
