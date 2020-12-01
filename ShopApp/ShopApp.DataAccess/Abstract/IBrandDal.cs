using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Abstract
{
   public interface IBrandDal:IRepository<Brand>
    {
        Brand GetByIdWithProduct(int id);
        void DeleteFromBrand(int brandId, int productId);
    }
}
