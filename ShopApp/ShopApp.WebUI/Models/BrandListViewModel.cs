using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class BrandListViewModel
    {
        public string SelectedBrand { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
