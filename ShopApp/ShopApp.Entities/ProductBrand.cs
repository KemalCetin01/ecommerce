using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Entities
{
   public class ProductBrand
    {
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
