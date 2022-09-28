using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Order GetOrderById(int uplata_id);
        Order CreateOrder(Order uplata);
        Order UpdateOrder(Order uplata);
        void DeleteOrder(int uplata_id);
        bool SaveChanges();
        void FulfillOrder(Stripe.Checkout.Session session);
    }
}
