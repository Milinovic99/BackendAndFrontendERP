using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IDeliveryRepository
    {
        List<Delivery> GetDeliveries(string address=null,string city=null);
        Delivery GetDeliveryById(int podaci_id);
        Delivery CreateDelivery(Delivery podaci_o_dostavi);
        Delivery UpdateDelivery(Delivery podaci_o_dostavi);
        void DeleteDelivery(int podaci_id);
        bool SaveChanges();
    }
}
