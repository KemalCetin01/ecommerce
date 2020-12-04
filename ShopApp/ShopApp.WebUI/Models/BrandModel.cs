using ShopApp.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models
{
    public class BrandModel
    {
        public int Id { get; set; }

        [Display(Name = "Marka Adı")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}
