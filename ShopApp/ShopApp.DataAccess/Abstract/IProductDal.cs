using ShopApp.Entities;
using System.Collections.Generic;

namespace ShopApp.DataAccess.Abstract 
{
    public interface IProductDal:IRepository<Product>
    {
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        Product GetProductDetails(int id);
        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
        List<Product> GetProductsByBrand(string brand, int page, int pageSize);
        int GetCountByBrand(string brand);
    }
}
