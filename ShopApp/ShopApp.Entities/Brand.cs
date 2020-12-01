using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Entities
{
  public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  List<ProductBrand> ProductBrands { get; set; }

    }
}
