using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.DTO
{
  public class UserDTO
  {
    public string Name { get; set; } 
    public string LastName { get; set; }
    public string Email { get; set; }
    public string User_name { get; set; }
    public string Password { get; set; }
    [ForeignKey("Role")]
    public int Role_id { get; set; }
    public int Purchase_count { get; set; }
  }
}
