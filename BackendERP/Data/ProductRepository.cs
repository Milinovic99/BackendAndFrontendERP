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
    public void ReduceProductsOnInventory(List<Product> products)
    {
      for (int i = 0; i < products.Count; i++)
      {
        //if there are enough product quantity on inventory, we must reduce number of products in warehouse
        Product reducedProduct = context.Products.FirstOrDefault(p => p.Product_id == products[i].Product_id);
        if (reducedProduct != null)
          reducedProduct.Product_quantity -= products[i].Product_quantity;
        context.SaveChanges();
      }
    }
    public bool CheckQuantity(Product product)
    {
      Product foundProduct = context.Products.FirstOrDefault(p => p.Product_name == product.Product_name);
      if (foundProduct.Product_quantity < product.Product_quantity)
      {
        return false;
      }
      else
        return true;
    }
  }
}
