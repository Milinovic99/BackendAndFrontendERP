using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IProductRepository
    {
        List<Product> GetProducts(string name = null);
        Product GetProductById(int proizvod_id);
        Product CreateProduct(Product proizvod);
        Product UpdateProduct(Product proizvod);
        void DeleteProduct(int proizvod_id);
        bool SaveChanges();
        public void ReduceProductsOnInventory(List<Product> products);
         public bool CheckQuantity(Product product);
    }
}
