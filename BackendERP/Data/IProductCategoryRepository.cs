using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public interface IProductCategoryRepository
    {
        List<Product_category> GetProductCategories(string kategorija=null);
        Product_category GetProductCategoryById(int kategorija_id);
        Product_category CreateProductCategory(Product_category kategorija);
        Product_category UpdateProductCategory(Product_category kategorija);
        void DeleteProductCategory(int kategorija_id);
        bool SaveChanges();
    }
}
