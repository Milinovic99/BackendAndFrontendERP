using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public PaymentRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Payment CreatePayment(Payment uplata)
        {
            throw new NotImplementedException();
        }

        public void DeletePayment(int uplata_id)
        {
            throw new NotImplementedException();
        }

        public Payment GetPaymentById(int uplata_id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPayments()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Payment UpdatePayment(Payment uplata)
        {
            throw new NotImplementedException();
        }
    }
}
