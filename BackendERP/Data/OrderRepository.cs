using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class OrderRepository:IOrderRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private Order order=new();

        public OrderRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

       public Order CreateOrder(Order uplata)
        {
            var createdEntity = context.Add(uplata);
            return mapper.Map<Order>(createdEntity.Entity);
        }

        public void DeleteOrder(int uplata_id)
        {
            var uplata = GetOrderById(uplata_id);
            context.Remove(uplata);
        }

        public Order GetOrderById(int uplata_id)
        {
              return context.Orders.FirstOrDefault(e => e.Order_id == uplata_id);
           
        }

        public List<Order> GetOrders()
        {
              return (from e in context.Orders
                   select e).ToList();
           
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }



        public Order UpdateOrder(Order uplata)
        {
            throw new NotImplementedException();
        }


    public void FulfillOrder(Stripe.Checkout.Session session)
    {
      User user = context.Users.FirstOrDefault(u => u.Email == session.CustomerDetails.Email);

       order = new()
      {
        Total = (double)session.AmountTotal,
        Order_date = DateTime.Now,
        User_id = user.User_id
      };
      context.Add(order);

      for(int i=0; i < session.LineItems.Count(); i++)
      {
        OrderProduct orderProduct = new()
        {
          Order_id= order.Order_id,
          Product_id= int.Parse(session.LineItems.ElementAt(i).ProductId),
          BoughtProducts_amount = ((int)session.LineItems.ElementAt(i).Quantity.Value),
        };
        context.Add(orderProduct);
      }
      context.SaveChanges();
    }
  }
}
