using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class Newsletter
    {
        [Key]
        public int Newsletter_id { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Neophodno je unijeti email adresu")]
        public string Email { get; set; }
    }

}
