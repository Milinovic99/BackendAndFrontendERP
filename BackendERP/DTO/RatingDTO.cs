using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.DTO
{
  public class RatingDTO
  {
    public int Grade { get; set; }
    public string Comment { get; set; }
    [ForeignKey("Product")]
    public int Product_id { get; set; }
    [ForeignKey("User")]
    public int User_id { get; set; }
  }
}
