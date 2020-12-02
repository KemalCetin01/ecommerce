using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    [Authorize(Roles ="admin")] //login olan kullanıcı 
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IBrandService _brandService;
        public AdminController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }
        public IActionResult ProductList()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };
                if (_productService.Create(entity))
                {
                    return RedirectToAction("ProductList");
                }
                ViewBag.ErrorMessage = _productService.ErrorMessage;
                return View(model);
            }
            return View(model);
        }

        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategories((int)id);

            if (entity == null)
            {
                return NotFound();
            }
            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                SelectedCategories = entity.ProductCategories.Select(i => i.Category).ToList(),
                Dimensions = entity.Dimensions,
                Material = entity.Material,
                Model = entity.Model,
                SequenceMeter = entity.SequenceMeter,
                WarrantyPeriod = entity.WarrantyPeriod,
                SelectedBrands = entity.ProductBrands.Select(i => i.Brand).FirstOrDefault()
            };

            List<SelectListItem> ListBrands = new List<SelectListItem>();

            List<Brand> GetAllBrands = _brandService.GetAll();
            GetAllBrands.ForEach(x =>
            {
                ListBrands.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            });
            model.Brands = ListBrands;



            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Brands = _brandService.GetAll();
            

            ViewBag.ErrorMessage = _productService.ErrorMessage;
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel model,int[] categoryIds,IFormFile file) //TASK--> TPL kütüphanesi
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Price = model.Price;

                if (file != null)
                {
                    entity.ImageUrl = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",file.FileName);
                    using (var stream=new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                 
                _productService.Update(entity, categoryIds);

                return RedirectToAction("ProductList");
            }
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Brands = _categoryService.GetAll();

            ViewBag.ErrorMessage = _productService.ErrorMessage;
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);

            if (entity != null)
            {
                _productService.Delete(entity);
            }

            return RedirectToAction("ProductList");
        }

        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };
            _categoryService.Create(entity);

            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetByIdWithProduct(id);

            return View(new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Products = entity.ProductCategories.Select(p => p.Product).ToList()
            });
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            _categoryService.Update(entity);

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);

            if (entity != null)
            {
                _categoryService.Delete(entity);
            }

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int productId)
        {
            _categoryService.DeleteFromCategory(categoryId, productId);

            return Redirect("/admin/EditCategory/"+categoryId);
        }


        public IActionResult BrandList()
        {
            return View(new BrandListModel()
            {
                Brands = _brandService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBrand(BrandModel model)
        {
            var entity = new Brand()
            {
                Name = model.Name
            };
            _brandService.Create(entity);

            return RedirectToAction("BrandList");
        }

        [HttpGet]
        public IActionResult EditBrand(int id)
        {
            var entity = _brandService.GetByIdWithProduct(id);

            return View(new BrandModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Products = entity.ProductBrands.Select(p => p.Product).ToList()
            });
        }
        [HttpPost]
        public IActionResult EditBrand(BrandModel model)
        {
            var entity = _brandService.GetById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            _brandService.Update(entity);

            return RedirectToAction("BrandList");
        }

        [HttpPost]
        public IActionResult DeleteBrand(int brandId)
        {
            var entity = _brandService.GetById(brandId);

            if (entity != null)
            {
                _brandService.Delete(entity);
            }

            return RedirectToAction("BrandList");
        }

        [HttpPost]
        public IActionResult DeleteFromBrand(int brandId, int productId)
        {
            _brandService.DeleteFromBrand(brandId, productId);

            return Redirect("/admin/EditBrand/" + brandId);
        }

    }
}