using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface INewsletterRepository
    {
        List<Newsletter> GetNewsletters();
        Newsletter GetNewsletterById(int assortment_id);
        Newsletter CreateNewsletter(Newsletter assortment);
        Newsletter UpdateNewsletter(Newsletter assortment);
        void DeleteNewsletter(int assortment_id);
        bool SaveChanges();
    }
}
