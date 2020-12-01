using ShopApp.Entities;
using System.Collections.Generic;

namespace ShopApp.Business.Abstract
{
   public interface IProductService:IValidator<Product>
    {
        Product GetById(int id);
        Product GetProductDetails(int id);
        List<Product> GetAll();
        List<Product> GetProductsByCategory(string category,int page, int pageSize);
        List<Product> GetProductsByBrand(string brand,int page, int pageSize);
        bool Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        int GetCountByCategory(string category);
        int GetCountByBrand(string brand);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
