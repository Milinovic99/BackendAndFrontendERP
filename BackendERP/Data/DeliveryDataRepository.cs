using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class DeliveryDataRepository :IDeliveryDataRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public DeliveryDataRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Delivery_data CreateDeliveryData(Delivery_data podaci_o_dostavi)
        {
            var createdEntity = context.Add(podaci_o_dostavi);
            return mapper.Map<Delivery_data>(createdEntity.Entity);

        }

        public void DeleteDeliveryData(int podaci_id)
        {
            var radnja = GetDeliveryDataById(podaci_id);
            context.Remove(radnja);
        }

        public List<Delivery_data> GetDeliveryData(string address=null,string city=null)
        {
            return (from e in context.Delivery_data
                    where (string.IsNullOrEmpty(address) && string.IsNullOrEmpty(city)) ||
                   ( e.Address == address || e.City == city) select e).ToList();

        }

        public Delivery_data GetDeliveryDataById(int podaci_id)
        {
            return context.Delivery_data.FirstOrDefault(e => e.Delivery_id == podaci_id);

        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Delivery_data UpdateDeliveryData(Delivery_data podaci_o_dostavi)
        {
            throw new NotImplementedException();
        }
    }
}
