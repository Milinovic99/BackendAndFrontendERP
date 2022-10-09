using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.DTO
{
  public class DeliveryDTO
  {   
    public string Phone_number { get; set; } 
    public string Address { get; set; }
    public string City { get; set; }
    [ForeignKey("Order")]
    public int Order_id { get; set; }
  }
}
