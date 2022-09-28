using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        

        public ProductRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Product CreateProduct(Product proizvod)
        {
              var createdEntity = context.Add(proizvod);
            return mapper.Map<Product>(createdEntity.Entity);
        }

        public void DeleteProduct(int proizvod_id)
        {
            var radnja = GetProductById(proizvod_id);
            context.Remove(radnja);
           
        }

        public Product GetProductById(int proizvod_id)
        {
            return context.Products.FirstOrDefault(e => e.Product_id == proizvod_id);
        }

        public List<Product> GetProducts(string name = null)
        {
            return (from e in context.Products
                    where string.IsNullOrEmpty(name) || e.Product_name == name
                    select e).ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Product UpdateProduct(Product proizvod)
        {
            throw new NotImplementedException();
        }
    }
}
