using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService) //ctor constructor
        {
            _productService = productService;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList(),
                Brands=product.ProductBrands.Select(i=>i.Brand).FirstOrDefault()
            });;
        }
        public IActionResult List(string category,string brand, int page = 1)
        {
            const int pageSize = 3;
            //return View(_productService.GetAll());
            if (brand!=null)
            {

                return View(new ProductListModel()
                {
                    Products = _productService.GetProductsByBrand(brand, page, pageSize),
                    PageInfo = new PageInfo()
                    {
                        TotalItems = _productService.GetCountByBrand(brand),
                        CurrentPage = page,
                        ItemPerPage = pageSize,
                        CurrentCategory = null,
                        CurrentBrand = brand
                    }
                });
            }
            return View(new ProductListModel()
            {
                Products = _productService.GetProductsByCategory(category, page, pageSize),
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemPerPage = pageSize,
                    CurrentCategory = category,
                    CurrentBrand = null
                }
            }) ;

        }
    }
}
