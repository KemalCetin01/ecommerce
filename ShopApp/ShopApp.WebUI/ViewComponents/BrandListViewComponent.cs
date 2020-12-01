using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.ViewComponents
{
    public class BrandListViewComponent : ViewComponent
    {
        private IBrandService _brandService;
        public BrandListViewComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new BrandListViewModel()
            {
                SelectedBrand = RouteData.Values["brand"]?.ToString(), //startup MapRoute tan alır. querystring gibi. 
                Brands = _brandService.GetAll()
            });
        }

    }
}
