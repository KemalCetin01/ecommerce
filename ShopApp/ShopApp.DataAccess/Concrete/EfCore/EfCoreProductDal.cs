using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, ShopContext>, IProductDal
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context=new ShopContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Include(i=>i.ProductBrands)
                    .ThenInclude(i=>i.Brand)
                    .FirstOrDefault();
            }
        }

        public int GetCountByBrand(string brand)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable(); //AsQueryable-->list denmediği sürece sorguyu değiştirebiliyorsunuz 
                                                               //ekstradan where,order by sorgusu gibi ekstra kriter eklenebilir

                if (!string.IsNullOrEmpty(brand))
                {
                    products = products
                          .Include(i => i.ProductBrands)
                          .ThenInclude(i => i.Brand)
                          .Where(i => i.ProductBrands.Any(a => a.Brand.Name.ToLower() == brand.ToLower()));
                }
                return products.Count();

            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable(); //AsQueryable-->list denmediği sürece sorguyu değiştirebiliyorsunuz 
                                                               //ekstradan where,order by sorgusu gibi ekstra kriter eklenebilir

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                          .Include(i => i.ProductCategories)
                          .ThenInclude(i => i.Category)
                          .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Count();

            }
        }

        public Product GetProductDetails(int id)
        {
            using (var context=new ShopContext())
            {
                return context.Products
                    .Where(i=>i.Id==id)
                    .Include(i=>i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Include(i=>i.ProductBrands)
                    .ThenInclude(i=>i.Brand)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByBrand(string brand, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable(); //AsQueryable-->list denmediği sürece sorguyu değiştirebiliyorsunuz 
                                                               //ekstradan where,order by sorgusu gibi ekstra kriter eklenebilir

                if (!string.IsNullOrEmpty(brand))
                {
                    products = products
                          .Include(i => i.ProductBrands)
                          .ThenInclude(i => i.Brand)
                          .Where(i => i.ProductBrands.Any(a => a.Brand.Name.ToLower() == brand.ToLower()));
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();//Skip Ötele , Take al

            }
        }

        public List<Product> GetProductsByCategory(string category, int page,int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable(); //AsQueryable-->list denmediği sürece sorguyu değiştirebiliyorsunuz 
                                                               //ekstradan where,order by sorgusu gibi ekstra kriter eklenebilir

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                          .Include(i => i.ProductCategories)
                          .ThenInclude(i => i.Category)
                          .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();//Skip Ötele , Take al

            }
        }

        public void Update(Product entity, int[] categoryIds, int brandId)
        {
            using (var context=new ShopContext())
            {
                var product = context.Products
                                    .Include(i => i.ProductCategories)
                                    .Include(i=>i.ProductBrands)
                                    .FirstOrDefault(i=>i.Id==entity.Id);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.ImageUrl = entity.ImageUrl;
                    product.Price = entity.Price;
                    product.Material = entity.Material;
                    product.Model = entity.Model;
                    product.SequenceMeter = entity.SequenceMeter;
                    product.WarrantyPeriod = entity.WarrantyPeriod;

                   

                    product.ProductCategories = categoryIds.Select(catid=>new ProductCategory()
                    { 
                    CategoryId=catid,
                    ProductId=entity.Id
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}
