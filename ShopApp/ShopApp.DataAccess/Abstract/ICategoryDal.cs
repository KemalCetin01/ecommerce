using ShopApp.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ShopApp.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        Category GetByIdWithProduct(int id);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
