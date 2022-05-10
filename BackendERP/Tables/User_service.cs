using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class User_service
    {
        [Key]
        public int Service_id { get; set; }
        [Required(ErrorMessage = "Email je neophodno unijeti")]
        [EmailAddress(ErrorMessage = "Unesite ispravnu email adresu")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Poruku je neophodno unijeti")]
        public string Message { get; set; }
    }
}
