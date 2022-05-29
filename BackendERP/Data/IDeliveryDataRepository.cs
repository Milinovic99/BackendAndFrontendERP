using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IDeliveryDataRepository
    {
        List<Delivery_data> GetDeliveryData(string address=null,string city=null);
        Delivery_data GetDeliveryDataById(int podaci_id);
        Delivery_data CreateDeliveryData(Delivery_data podaci_o_dostavi);
        Delivery_data UpdateDeliveryData(Delivery_data podaci_o_dostavi);
        void DeleteDeliveryData(int podaci_id);
        bool SaveChanges();
    }
}
