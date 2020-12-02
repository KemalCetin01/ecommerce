using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System.Collections.Generic;

namespace ShopApp.Business.Concrete
{
  
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        //EfCoreProductDal _productDal = new EfCoreProductDal();
        public ProductManager (IProductDal productDal)
        {
            _productDal = productDal;
        }


        public bool Create(Product entity)
        {
            if (Validate(entity))
            {
                _productDal.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productDal.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productDal.GetCountByCategory(category);
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategory(string category,int page, int pageSize)
        {
            return _productDal.GetProductsByCategory(category,page, pageSize);
        }
        public List<Product> GetProductsByBrand(string brand,int page, int pageSize)
        {
            return _productDal.GetProductsByBrand(brand,page, pageSize);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public void Update(Product entity, int[] categoryIds, int brandId)
        {
            _productDal.Update(entity, categoryIds,brandId);
        }

        public bool Validate(Product entity)
        {
            var isValid = true;
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "Ürün İsmi Girmelisiniz.";
                isValid = false;
            }
            return isValid;
        }

        public int GetCountByBrand(string brand)
        {
            return _productDal.GetCountByBrand(brand);
        }

        public string ErrorMessage { get; set; }

    }
}
