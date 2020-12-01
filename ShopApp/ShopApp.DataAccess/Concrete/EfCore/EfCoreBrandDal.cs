using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System.Linq;
namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreBrandDal : EfCoreGenericRepository<Brand, ShopContext>, IBrandDal
    {
        public void DeleteFromBrand(int brandId, int productId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"delete from ProductBrand where ProductId=@p0 and BrandId=@p1";
                context.Database.ExecuteSqlCommand(cmd, productId, brandId);
            }
        }

        public Brand GetByIdWithProduct(int id)
        {
            using (var context=new ShopContext())
            {
                return context.Brands
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductBrands)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
            }
        }
    }
}
