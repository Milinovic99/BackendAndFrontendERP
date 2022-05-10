using AutoMapper;
using BackendERP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendERP.Data
{
    public class ProductCategoryRepository:IProductCategoryRepository
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public ProductCategoryRepository(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Product_category CreateProductCategory(Product_category kategorija)
        {
            var createdEntity = context.Add(kategorija);
            return mapper.Map<Product_category>(createdEntity.Entity);
        }

        public void DeleteProductCategory(int kategorija_id)
        {
            var kategorija = GetProductCategoryById(kategorija_id);
            context.Remove(kategorija);
        }

        public Product_category GetProductCategoryById(int kategorija_id)
        {
            return context.Product_categories.FirstOrDefault(e => e.Category_id == kategorija_id);

        }

        public List<Product_category> GetProductCategories(string kategorija=null)
        {
            return (from e in context.Product_categories
                    where string.IsNullOrEmpty(kategorija) || e.Category_name==kategorija
                    select e).ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Product_category UpdateProductCategory(Product_category kategorija)
        {
            throw new NotImplementedException();
        }
    }
}
