using ShopApp.Entities;
using System.Collections.Generic;

namespace ShopApp.Business.Abstract
{
   public interface IBrandService
    {
        Brand GetById(int id);
        Brand GetByIdWithProduct(int id);
        List<Brand> GetAll();
        void Create(Brand entity);
        void Update(Brand entity);
        void Delete(Brand entity);
        void DeleteFromBrand(int brandId, int productId);
    }
}
