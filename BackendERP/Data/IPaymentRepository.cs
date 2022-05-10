using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IPaymentRepository
    {
        List<Payment> GetPayments();
        Payment GetPaymentById(int uplata_id);
        Payment CreatePayment(Payment uplata);
        Payment UpdatePayment(Payment uplata);
        void DeletePayment(int uplata_id);
        bool SaveChanges();
    }
}
