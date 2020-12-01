using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Create(Brand entity)
        {
            _brandDal.Create(entity);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public void DeleteFromBrand(int brandId, int productId)
        {
            _brandDal.DeleteFromBrand(brandId, productId);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public Brand GetByIdWithProduct(int id)
        {
            return _brandDal.GetByIdWithProduct(id);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
