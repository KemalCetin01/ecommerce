using System;
using System.Collections.Generic;

namespace ShopApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String ImageUrl { get; set; }
        public String Description { get; set; }
        public decimal? Price { get; set; }


        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductBrand> ProductBrands { get; set; }

    }
}
