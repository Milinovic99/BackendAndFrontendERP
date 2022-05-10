using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class NewsletterRepository :INewsletterRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public NewsletterRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Newsletter CreateNewsletter(Newsletter cjenovnik)
        {
            var createdEntity = context.Add(cjenovnik);
            return mapper.Map<Newsletter>(createdEntity.Entity);
        }

        public void DeleteNewsletter(int cjenovnik_id)
        {
            var radnja = GetNewsletterById(cjenovnik_id);
            context.Remove(radnja);
        }

        public List<Newsletter> GetNewsletters()
        {
            return context.Newsletters.ToList();
        }

        public Newsletter GetNewsletterById(int Assortment_id)
        {
            return context.Newsletters
                .FirstOrDefault(e => e.Newsletter_id == Assortment_id);

        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Newsletter UpdateNewsletter(Newsletter assortment)
        {
            throw new NotImplementedException();
        }
    }
}
