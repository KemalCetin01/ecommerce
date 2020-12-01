using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı")]
        public String Name { get; set; }
        [Display(Name = "Ürün Kodu")]
        public String Code { get; set; }
        public String ImageUrl { get; set; }
        public String Description { get; set; }
        [Display(Name = "Fiyatı")]
        public decimal? Price { get; set; }
        [Display(Name = "Boyut")]
        public  String Dimensions { get; set; }
        [Display(Name = "Model")]
        public  String Model { get; set; }
        [Display(Name = "MetreKare")]
        public decimal? SequenceMeter { get; set; }
        [Display(Name = "Materyal")]
        public String Material { get; set; }
        [Display(Name = "Garanti Süresi")]
        public decimal? WarrantyPeriod { get; set; } //garanti süresi
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductBrand> ProductBrands { get; set; }

    }
}
