using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        [Required(ErrorMessage = "Ime je neophodno unijeti")]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Ime mora sadrzati iskljucivo slova!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Prezime je neophodno unijeti")]
        [StringLength(35, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Prezime mora sadrzati iskljucivo slova!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email je neophodno unijeti")]
        [StringLength(30, MinimumLength = 10)]
        [EmailAddress(ErrorMessage = "Unesite ispravnu email adresu")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Korisnicko ime je neophodno unijeti")]
        [StringLength(30, MinimumLength = 5)]
        public string User_name { get; set; }
        [Required(ErrorMessage = "Lozinku je neophodno unijeti")]
        [StringLength(30, MinimumLength = 5)]
        public string Password { get; set; }
        [ForeignKey("Role")]
        public int Role_id { get; set; }

        public int Purchase_count { get; set; }
         public Role Role { get; set; }

        public List<Order> Orders;
        public List<Rating> Ratings { get; set; }

        
    }
}
