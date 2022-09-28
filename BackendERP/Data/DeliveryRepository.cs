using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class DeliveryRepository:IDeliveryRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public DeliveryRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
       public Delivery CreateDelivery(Delivery podaci_o_dostavi)
        {
            var createdEntity = context.Add(podaci_o_dostavi);
            return mapper.Map<Delivery>(createdEntity.Entity);

        }

        public void DeleteDelivery(int podaci_id)
        {
            var radnja = GetDeliveryById(podaci_id);
            context.Remove(radnja);
        }

        public List<Delivery> GetDeliveries(string address=null,string city=null)
        {
             return (from e in context.Delivery
                   where (string.IsNullOrEmpty(address) && string.IsNullOrEmpty(city)) ||
                ( e.Address == address || e.City == city) select e).ToList();
            
        }

        public Delivery GetDeliveryById(int podaci_id)
        {
              return context.Delivery.FirstOrDefault(e => e.Delivery_id == podaci_id);
            
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Delivery UpdateDelivery(Delivery podaci_o_dostavi)
        {
            throw new NotImplementedException();
        }
  
    }

}
