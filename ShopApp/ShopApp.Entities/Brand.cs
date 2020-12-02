using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.Entities
{
  public class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Markası")]
        public string Name { get; set; }

        public  List<ProductBrand> ProductBrands { get; set; }

    }
}
