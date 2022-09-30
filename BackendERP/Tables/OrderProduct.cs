using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Tables
{
  public class OrderProduct
  {
    public int Order_id { get; set; }

    public int Product_id { get; set; }

    public int BoughtProducts_amount { get; set; }
  }
}
